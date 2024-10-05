---
title: 外部リンクされた画像を使用してプレゼンテーションをHTMLにエクスポートする
type: docs
weight: 100
url: /net/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

ここでのプレゼンテーションからHTMLへのエクスポート手順では、以下を指定できます。

1. 結果として得られるHTMLファイルに埋め込まれるリソース
2. 外部に保存され、HTMLファイルから参照されるリソース。

{{% /alert %}} 

## **背景**

デフォルトのHTMLエクスポートの動作は、すべてのリソースをbase64エンコーディングを通じてHTMLファイル内に埋め込むことです。このアプローチは、閲覧や配布が便利な単一のHTMLファイルを出力します。ただし、デフォルトのアプローチには以下の制限があります：

* 出力されるファイルは、base64エンコーディングのためにその構成要素よりも大幅に大きくなります。
* ファイル内に含まれる画像やリソースは、置き換えるのが難しいです。

### **別のアプローチ**

**[ILinkEmbedController](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/)** を含む別のアプローチは、上記の制限を回避します。  

`LinkController`クラスは`ILinkEmbedController`インターフェイスを実装しています。このインターフェイスは、[HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/htmloptions/#constructor)クラスのコンストラクタに渡されます。ILinkEmbedControllerインターフェイスには、リソースの埋め込みと保存プロセスを制御する3つのメソッドがあります：

**[GetObjectStoringLocation](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation)(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension)**: このメソッドは、エクスポータがリソースに遭遇し、リソースをどのように保存するかを決定する必要があるときに呼び出されます。*id*（エクスポート操作のリソース一意識別子）と*contentType*（リソースのMIMEタイプを含む）は、メソッドの中で最も重要なパラメータです。リソースをリンクしたい場合は、メソッドから[LinkEmbedDecision.Link](https://reference.aspose.com/slides/net/aspose.slides.export/linkembeddecision/)列挙型を返す必要があります。それ以外の場合（リソースを埋め込むには）、[LinkEmbedDecision.Embed](https://reference.aspose.com/slides/net/aspose.slides.export/linkembeddecision/)を返す必要があります。

**[GetUrl](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/geturl)(int id, int referrer)**: このメソッドは、結果ファイルで使用される形式のリソースURLを取得するために呼び出されます。リソースは*id*で識別されます。

**[SaveExternal](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/saveexternal)(int id, byte[] entityData)**: シーケンスの最終メソッドとして、リソースを外部に保存する時点で呼び出されます。リソース識別子とリソース内容がバイト配列に存在するため、リソースデータであらゆる種類の操作を実行できます。

このC#コードは**LinkController**クラスが**ILinkEmbedController**インターフェイスを実装しています：

```c#
class LinkController : ILinkEmbedController
{
    static LinkController()
    {
        s_templates.Add("image/jpeg", "image-{0}.jpg");
        s_templates.Add("image/png", "image-{0}.png");
    }

    /// <summary>
    /// デフォルトのパラメータなしコンストラクタ
    /// </summary>
    public LinkController()
    {
        m_externalImages = new Dictionary<int, string>();
    }

    /// <summary>
    /// クラスのインスタンスを作成し、生成されたリソースファイルが保存されるパスを設定します。
    /// </summary>
    /// <param name="savePath">生成されたリソースファイルが保存される場所へのパス。</param>
    public LinkController(string savePath)
        : this()
    {
        SavePath = savePath;
    }

    /// <summary>
    /// A ILinkEmbedControllerメンバー
    /// </summary>
    public LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName,
        string contentType,
        string recomendedExtension)
    {
        // ここで、画像を外部に保存するかどうかを決定します。
        // idは、全体のエクスポート操作中の各オブジェクトの一意識別子です。

        string template;

        // s_templates辞書には、外部に保存する予定のコンテンツタイプと、それに対応するファイル名テンプレートが含まれています。
        if (s_templates.TryGetValue(contentType, out template))
        {
            // このリソースをエクスポートリストに保存
            m_externalImages.Add(id, template);
            return LinkEmbedDecision.Link;
        }

        // 他のすべてのリソースは、あれば埋め込まれます
        return LinkEmbedDecision.Embed;
    }

    /// <summary>
    /// A ILinkEmbedControllerメンバー
    /// </summary>
    public string GetUrl(int id, int referrer)
    {
        // ここで、リソース参照文字列を構築してタグを形成します: <img src="%result%">
        // 不要なリソースをフィルタリングするために辞書をチェックする必要があります。
        // チェックと同時に、対応するファイル名テンプレートを抽出します。
        string template;
        if (m_externalImages.TryGetValue(id, out template))
        {
            // リソースファイルをHTMLファイルの近くに保存すると仮定します。
            // 画像タグは適切なリソースIDと拡張子を持つ形で<img src="image-1.png">のようになります。
            var fileUrl = String.Format(template, id);
            return fileUrl;
        }

        // 埋め込まれたままのリソースのためにnullを返す必要があります
        return null;
    }

    /// <summary>
    /// A ILinkEmbedControllerメンバー
    /// </summary>
    public void SaveExternal(int id, byte[] entityData)
    {
        // ここで、リソースファイルをディスクに実際に保存します。
        // 再度、辞書をチェックします。ここにidが見つからない場合は、GetObjectStoringLocationまたはGetUrlメソッドにエラーの兆候があります。
        if (m_externalImages.ContainsKey(id))
        {
            // 今、辞書に保存されたファイル名を使用し、必要に応じてパスと結合します。

            // 保存されたテンプレートとIdを使用してファイル名を構築します。
            var fileName = String.Format(m_externalImages[id], id);

            // 場所のディレクトリと組み合わせます
            var filePath = Path.Combine(SavePath ?? String.Empty, fileName);

            using (var fs = new FileStream(filePath, FileMode.Create))
                fs.Write(entityData, 0, entityData.Length);
        }
        else
            throw new Exception("何かがおかしい");
    }

    /// <summary>
    /// 生成されたリソースファイルが保存されるパスを取得または設定します。
    /// </summary>
    public string SavePath { get; set; }

    /// <summary>
    /// リソースIDと対応するファイル名の関連付けを保存する辞書です。
    /// </summary>
    private readonly Dictionary<int, string> m_externalImages;

    /// <summary>
    /// 外部に保存する予定のリソースのコンテンツタイプと、それに対応するファイル名テンプレートの関連付けを保存する辞書です。
    /// </summary>
    private static readonly Dictionary<string, string> s_templates = new Dictionary<string, string>();
}
```

**LinkController**クラスを書いた後、次のように**HTMLOptions**クラスと組み合わせて、外部リンクされた画像を持つプレゼンテーションをHTMLにエクスポートできます：

```c#
using (var pres = new Presentation(@"C:\data\input.pptx")) {

    var htmlOptions = new HtmlOptions(new LinkController(@"C:\data\out\"));
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(new SVGOptions());
    // この行は、HTMLでスライドタイトルを表示しないために必要です。
    // スライドタイトルの表示を希望する場合は、この行をコメントアウトしてください。
    htmlOptions.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(String.Empty, false);

    Console.WriteLine("エクスポートを開始します");
    pres.Save(@"C:\data\out\output.html", SaveFormat.Html, htmlOptions);
}
```

`SlideImageFormat.Svg`を`SlideImageFormat`プロパティに割り当てることにより、結果として得られるHTMLファイルにはプレゼンテーションの内容を描画するためのSVGデータが含まれます。

コンテンツタイプ：プレゼンテーションにラスタビットマップが含まれている場合、クラスコードは'image/jpeg'および'image/png'コンテンツタイプの両方を処理できるように準備されている必要があります。エクスポートされたビットマップ画像の内容は、プレゼンテーションに保存されていたものと一致しない場合があります。Aspose.Slidesの内部アルゴリズムはサイズ最適化を行い、どちらが小さいデータサイズを生成するかに応じてJPGまたはPNGコーデックを使用します。アルファチャネル（透過）を含む画像は常にPNGにエンコードされます。