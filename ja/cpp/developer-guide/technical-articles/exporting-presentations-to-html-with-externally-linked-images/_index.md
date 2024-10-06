---
title: 外部リンク画像を使用したプレゼンテーションのHTMLへのエクスポート
type: docs
weight: 50
url: /ja/cpp/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

この記事では、生成されるHTMLファイルに埋め込まれるリソースと外部で保存されHTMLファイルから参照されるリソースを制御することができる高度な技術について説明します。

{{% /alert %}} 
## **背景**
デフォルトのHTMLエクスポートの動作は、あらゆるリソースをHTMLファイルに埋め込むことです。このアプローチでは、閲覧および配布が容易な単一のHTMLファイルが生成されます。すべての必要なリソースは内部でbase64でエンコードされています。しかし、このアプローチには二つの欠点があります：

- base64エンコーディングのため、出力のサイズが大幅に大きくなります。そのため、ファイルに含まれる画像を置き換えることが難しいです。

この記事では、**Aspose.Slides for C++**を使用して画像をHTMLファイルに埋め込むのではなく外部リンクとして変更する方法を見ていきます。リソースの埋め込みと保存プロセスを制御するための三つのメソッドを含む[ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller)インターフェースを使用します。このインターフェースは、エクスポートの準備を行う際に[HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options)クラスのコンストラクタに渡すことができます。

以下は、[ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller)インターフェースを実装する**LinkController**クラスの完全なコードです。前述のように、**LinkController**は[ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller)インターフェースを実装しなければなりません。このインターフェースは三つのメソッドを指定します：

- **LinkEmbedDecision GetObjectStoringLocation(int32_t id, ArrayPtr<uint8_t> entityData, String semanticName, String contentType, String recomendedExtension)** エクスポータがリソースに遭遇し、それをどのように保存するか決定する必要があるときに呼び出されます。最も重要なパラメータは「id」 – エクスポート操作全体のリソースの一意の識別子と「contentType」 – リソースのMIMEタイプを含みます。リソースをリンクすることに決めた場合は、このメソッドからLinkEmbedDecision::Linkを返すべきです。そうでなければ、リソースを埋め込むためにLinkEmbedDecision::Embedを返すべきです。
- **String GetUrl(int32_t id, int32_t referrer)**
  結果ファイルで使用される形式のリソースURLを取得するために呼び出されます。たとえば、```<img src="%method_result_here%">```タグの形です。リソースは「id」で識別されます。
- **SaveExternal(int32_t id, ArrayPtr<uint8_t> entityData)** 
  シーケンスの最終的なメソッドで、リソースを外部に保存する必要があるときに呼び出されます。リソース識別子とリソース内容をバイト配列として持っています。提供されたリソースデータで何をするかは私たち次第です。

``` cpp
/// <summary>
/// このクラスは外部に保存されるリソースについての決定を行う責任があります。
/// Aspose::Slides::Export::ILinkEmbedControllerインターフェースを実装する必要があります。
/// </summary>
class LinkController : public ILinkEmbedController
{
public:
    LinkController()
    {
        m_externalImages = System::MakeObject<Dictionary<int32_t, String>>();
    }
    LinkController::LinkController(String savePath) : LinkController()
    {
        m_savePath = savePath;
    }

    LinkEmbedDecision GetObjectStoringLocation(int32_t id, ArrayPtr<uint8_t> entityData, 
        String semanticName, String contentType, String recomendedExtension) override
    {
        // ここで、画像を外部に保存することについての決定を行います。
        // idはエクスポート操作全体の各オブジェクトの一意の識別子です。

        String template_;

        // s_templates辞書には、外部に保存しようとしているコンテンツタイプとその対応するファイル名テンプレートが含まれています。
        if (s_templates->TryGetValue(contentType, template_))
        {
            // このリソースをエクスポートリストに保存
            m_externalImages->Add(id, template_);
            return LinkEmbedDecision::Link;
        }

        // 他のリソースはすべて、もしあれば、埋め込まれます
        return LinkEmbedDecision::Embed;
    }

    String GetUrl(int32_t id, int32_t referrer) override
    {
        // ここで、タグを形成するためのリソース参照文字列を構築します: <img src="%result%">
        // 不要なリソースを除外するために辞書をチェックする必要があります。
        // チェックと同時に、対応するファイル名テンプレートを抽出します。
        String template_;
        if (m_externalImages->TryGetValue(id, template_))
        {
            // リソースファイルをHTMLファイルの近くに保存することを想定しています。
            // 画像タグは、適切なリソースIdと拡張子を伴った <img src="image-1.png"> のようになります。
            String fileUrl = String::Format(template_, id);
            return fileUrl;
        }

        // 埋め込まれたままのリソースにはnullptrを返す必要があります
        return nullptr;
    }

    void SaveExternal(int32_t id, ArrayPtr<uint8_t> entityData) override
    {
        // ここで、実際にリソースファイルをディスクに保存します。
        // 再び、辞書をチェックします。idがここで見つからない場合は、GetObjectStoringLocationまたはGetUrlメソッドのエラーを示します。
        if (m_externalImages->ContainsKey(id))
        {
            // ここで、辞書に保存されたファイル名を使用し、必要に応じてパスと組み合わせます。

            // 保存されたテンプレートとIdを使用してファイル名を構築します。
            String fileName = String::Format(m_externalImages->idx_get(id), id);
            
            // 保存先ディレクトリと組み合わせます
            const String savePath = m_savePath != nullptr ? m_savePath : String::Empty;
            String filePath = Path::Combine(savePath, fileName);

            auto fs = System::MakeObject<FileStream>(filePath, FileMode::Create);
            fs->Write(entityData, 0, entityData->get_Length());
        }
        else
        {
            throw Exception(u"何かがおかしいです");
        }
    }

private:
    String m_savePath;
    SharedPtr<Dictionary<int32_t, String>> m_externalImages;
    static SharedPtr<Dictionary<String, String>> s_templates;

    static struct __StaticConstructor__
    {
        __StaticConstructor__()
        {
            s_templates->Add(u"image/jpeg", u"image-{0}.jpg");
            s_templates->Add(u"image/png", u"image-{0}.png");
        }
    } s_constructor__;
};
```

**LinkController**クラスを作成した後、次のコードを使用して[HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options)クラスと共に使用し、外部リンクされた画像を持つプレゼンテーションをHTMLにエクスポートします。

``` cpp
const String templatePath = u"../templates/image.pptx";
auto pres = System::MakeObject<Presentation>(templatePath);

auto htmlOptions = System::MakeObject<HtmlOptions>(System::MakeObject<LinkController>(GetOutPath()));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(System::MakeObject<SVGOptions>()));
// この行は、HTMLでスライドタイトル表示を削除するために必要です。
// スライドタイトルが表示されることを希望する場合は、そのコメントを外してください。
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));

pres->Save(GetOutPath() + u"/output.html", SaveFormat::Html, htmlOptions);
```

**SlideImageFormat::Svg**を**set_SlideImageFormat**メソッドに渡すことで、生成されたHTMLファイルにはプレゼンテーションの内容を描画するためのSVGデータが含まれることになります。

コンテンツタイプについては、プレゼンテーションに含まれる実際の画像データに依存します。プレゼンテーションにラスターのビットマップが含まれている場合、クラスのコードは「image/jpeg」と「image/png」の両方のコンテンツタイプを処理する準備が必要です。エクスポートされたラスターのビットマップの実際のコンテンツタイプは、プレゼンテーションに保存されている画像のコンテンツタイプと一致しない場合があります。Aspose.Slides for C++の内部アルゴリズムはサイズの最適化を行い、データサイズが小さい方いずれかのJPGまたはPNGコーデックを使用します。アルファチャンネル（透明性）を含む画像は常にPNGにエンコードされます。