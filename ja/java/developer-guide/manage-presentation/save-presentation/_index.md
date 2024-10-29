---
title: プレゼンテーションの保存
type: docs
weight: 80
url: /ja/java/save-presentation/
---

## **概要**
{{% alert color="primary" %}} 

[プレゼンテーションを開く](/slides/ja/java/open-presentation/)では、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスを使用してプレゼンテーションを開く方法を説明しています。この記事では、プレゼンテーションを作成して保存する方法を説明します。

{{% /alert %}} 

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスは、プレゼンテーションのコンテンツを保持します。ゼロからプレゼンテーションを作成する場合でも、既存のものを修正する場合でも、作業が終了したらプレゼンテーションを保存したいと思います。Aspose.Slides for Javaを使用すると、**ファイル**または**ストリーム**として保存できます。この記事では、プレゼンテーションをさまざまな方法で保存する方法を説明します。

## **プレゼンテーションをファイルに保存**
[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスの[**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-)メソッドを呼び出して、プレゼンテーションをファイルに保存します。単にファイル名と[**SaveFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/SaveFormat)を[**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-)メソッドに渡してください。

以下の例は、Aspose.Slides for Javaを使用してプレゼンテーションを保存する方法を示しています。

```java
// PPTファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation();
try {
    // ...ここで作業を行います...
    
    // プレゼンテーションをファイルに保存
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

## **プレゼンテーションをストリームに保存**
出力ストリームを[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスの[**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.io.OutputStream-int-)メソッドに渡すことで、プレゼンテーションをストリームに保存することができます。プレゼンテーションを保存できるストリームには多くの種類があります。以下の例では、新しいプレゼンテーションファイルを作成し、シェイプにテキストを追加して、プレゼンテーションをストリームに保存しています。

```java
// PPTファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // シェイプにテキストを追加
    shape.getTextFrame().setText("このデモでは、PowerPointファイルを作成してストリームに保存する方法を示します。");

    OutputStream os = new FileOutputStream("Save_As_Stream_out.pptx");

    pres.save(os, com.aspose.slides.SaveFormat.Pptx);

    os.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **定義されたビュータイプでプレゼンテーションを保存**
Aspose.Slides for Javaでは、生成されたプレゼンテーションがPowerPointで開かれたときのビュータイプを設定する機能を提供しています。[ViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties)クラスを使用します。[**setLastView**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#setLastView-int-)プロパティを使って、[**ViewType**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewType)列挙型を使ってビュータイプを設定します。

```java
// プレゼンテーションファイルを開く
Presentation pres = new Presentation();
try {
    // ビュータイプを設定
    pres.getViewProperties().setLastView((byte) ViewType.SlideMasterView);
    
    // プレゼンテーションを保存
    pres.save("newDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **厳密なOffice Open XML形式でプレゼンテーションを保存**
Aspose.Slidesでは、プレゼンテーションを厳密なOffice Open XML形式で保存することができます。その目的のために、プレゼンテーションファイルを保存する際にConformanceプロパティを設定できる[**PptxOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions)クラスを提供します。その値を[**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/java/com.aspose.slides/Conformance#Iso29500_2008_Strict)に設定すると、出力されるプレゼンテーションファイルは厳密なOpen XML形式で保存されます。

以下のサンプルコードは、プレゼンテーションを作成し、厳密なOffice Open XML形式で保存します。[**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)メソッドを呼び出すときに、Conformanceプロパティを[**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/java/com.aspose.slides/Conformance#Iso29500_2008_Strict)に設定した[PptxOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions)オブジェクトが渡されます。

```java
// PPTファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 線のタイプのオートシェイプを追加
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // 厳密なOffice Open XML形式の保存オプションを設定
    PptxOptions options = new PptxOptions();
    options.setConformance(Conformance.Iso29500_2008_Strict);
    
    // プレゼンテーションをファイルに保存
    pres.save("demoPass.pptx", SaveFormat.Pptx, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ZIP64モードでOffice Open XML形式にプレゼンテーションを保存**

Office Open XMLファイルは、未圧縮サイズのファイル、圧縮サイズのファイル、アーカイブの合計サイズに対して4GB（2^32バイト）の制限があり、アーカイブ内のファイル数は65,535（2^16-1）に制限されています。ZIP64形式の拡張により、制限が2^64に増加します。

新しい[**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/)プロパティを使用すると、保存されたOffice Open XMLファイルに対してZIP64形式の拡張を使用するタイミングを選択できます。

このプロパティには以下のモードがあります：

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#IfNecessary)は、プレゼンテーションが上記の制限を超える場合にのみZIP64形式の拡張が使用されることを意味します。これがデフォルトモードです。
- [Zip64Mode.Never](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#Never)は、ZIP64形式の拡張が使用されないことを意味します。
- [Zip64Mode.Always](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#Always)は、ZIP64形式の拡張が常に使用されることを意味します。

以下のコードは、ZIP64形式の拡張を使用してPPTX形式でプレゼンテーションを保存する方法を示しています。

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    PptxOptions pptxOptions = new PptxOptions();
    pptxOptions.setZip64Mode(Zip64Mode.Always);
    
    pres.save("Sample-zip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="注意" color="warning" %}}

Zip64Mode.Neverモードで保存すると、プレゼンテーションがZIP32形式で保存できない場合、[PptxException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxexception/)がスローされます。

{{% /alert %}}

## **進行状況をパーセントで保存**
新しい[**IProgressCallback**](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback)インターフェースが、[**ISaveOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/ISaveOptions)インターフェースと[**SaveOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/SaveOptions)抽象クラスに追加されました。[**IProgressCallback**](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback)インターフェースは、保存進行状況の更新をパーセントで報告するためのコールバックオブジェクトを表します。

以下のコードスニペットは、[IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback)インターフェースの使用方法を示しています。

```java
// プレゼンテーションファイルを開く
Presentation pres = new Presentation("ConvertToPDF.pptx");
try {
    ISaveOptions saveOptions = new PdfOptions();
    saveOptions.setProgressCallback((IProgressCallback) new ExportProgressHandler());
    pres.save("ConvertToPDF.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    pres.dispose();
}
```
```java
class ExportProgressHandler implements IProgressCallback 
{
    public void reporting(double progressValue) 
	{
        // ここで進行状況のパーセンテージ値を使用
        int progress = Double.valueOf(progressValue).intValue();
        System.out.println(progress + "% ファイルが変換されました");
    }
}
```

{{% alert title="情報" color="info" %}}

Asposeは独自のAPIを使用して、ユーザーがプレゼンテーションを複数のファイルに分割できる[無料のPowerPointスプリッターアプリ](https://products.aspose.app/slides/splitter)を開発しました。このアプリは、特定のプレゼンテーションから選択されたスライドを新しいPowerPoint（PPTXまたはPPT）ファイルとして保存します。

{{% /alert %}}