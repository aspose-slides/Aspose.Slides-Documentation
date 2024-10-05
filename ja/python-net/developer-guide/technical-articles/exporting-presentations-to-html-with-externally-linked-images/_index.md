---
title: 外部リンク画像を使ったHTMLへのプレゼンテーションのエクスポート
type: docs
weight: 100
url: /python-net/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

この記事では、生成されたHTMLファイルに埋め込まれるリソースと外部に保存されHTMLファイルから参照されるリソースを制御することができる高度な技術について説明します。

{{% /alert %}} 
## **背景**
デフォルトのHTMLエクスポートの動作は、リソースをHTMLファイルに埋め込むことです。このアプローチの結果、閲覧や配布が容易な単一のHTMLファイルが生成されます。すべての必要なリソースは内部にbase64エンコードされています。しかし、このアプローチには2つの欠点があります：

- 出力サイズがbase64エンコーディングのために著しく大きくなる。* ファイルに含まれる画像を置き換えるのが難しい。

この記事では、**Aspose.Slides for Python via .NET**を使用して、HTMLファイルに埋め込むのではなく、画像を外部リンクする方法を見ていきます。リソースの埋め込みおよび保存プロセスを制御するための3つのメソッドを含む**ILinkEmbedController**インターフェースを使用します。このインターフェースをHtmlOptionsクラスのコンストラクタに渡してエクスポートを準備します。

以下は、**ILinkEmbedController**インターフェースを実装する**LinkController**クラスの完全なコードです。前に述べたように、LinkControllerはILinkEmbedControllerインターフェースを実装しなければなりません。このインターフェースは、3つのメソッドを指定します：

- **public LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension)** エクスポーターがリソースに遭遇し、どのように保存するかを決定するために呼び出されます。最も重要なパラメーターは「id」– エクスポート操作全体に対するリソースの一意な識別子と「contentType」– リソースのMIMEタイプを含みます。リソースをリンクすることに決めた場合、このメソッドからLinkEmbedDecision.Linkを返す必要があります。そうでなければ、リソースを埋め込むためにLinkEmbedDecision.Embedを返す必要があります。
- **public string GetUrl(int id, int referrer)** 
  リソースのURLを取得するために呼び出され、その結果ファイルでどのように使用されるかを表す形式、たとえば<img src=”%method_result_here%”>タグで使用されます。リソースは「id」によって特定されます。
- **public void SaveExternal(int id, byte[] entityData)** 
  このシーケンスの最終メソッドで、リソースを外部に保存する際に呼び出されます。リソース識別子とリソースの内容をバイト配列として受け取ります。提供されたリソースデータを使って何をするかは私たち次第です。

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

**LinkController**クラスを書いた後、次のコードを使用して**HTMLOptions**クラスと共に、外部リンク画像を使用してプレゼンテーションをHTMLにエクスポートします。

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

**SlideImageFormat.Svg**を**SlideImageFormat**プロパティに割り当てたので、生成されたHTMLファイルにはプレゼンテーションの内容を描画するためのSVGデータが含まれます。

コンテンツタイプについては、プレゼンテーションに含まれる実際の画像データに依存します。プレゼンテーションにラスタビットマップが含まれている場合、クラスコードは「image/jpeg」と「image/png」両方のコンテンツタイプを処理できる準備をしなければなりません。エクスポートされたラスタビットマップ画像の実際のコンテンツタイプは、プレゼンテーションに格納された画像のそれと一致しない場合があります。Aspose.Slides内部アルゴリズムはサイズ最適化を行い、JPGまたはPNGコーデックのいずれかを使用して、どちらが小さいデータサイズを生成するかを選択します。アルファチャンネル（透明度）を含む画像は常にPNGにエンコードされます。