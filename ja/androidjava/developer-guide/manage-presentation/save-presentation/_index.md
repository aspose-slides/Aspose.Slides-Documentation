---
title: プレゼンテーションを保存
type: docs
weight: 80
url: /ja/androidjava/save-presentation/
---

## **概要**
{{% alert color="primary" %}} 

[プレゼンテーションを開く](/slides/ja/androidjava/open-presentation/)では、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスを使用してプレゼンテーションを開く方法について説明しました。この記事では、プレゼンテーションを作成して保存する方法を説明します。

{{% /alert %}} 

[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスはプレゼンテーションの内容を保持します。ゼロからプレゼンテーションを作成する場合でも、既存のものを変更する場合でも、完了したらプレゼンテーションを保存したいと思うでしょう。Aspose.Slides for Android via Javaでは、**ファイル**または**ストリーム**として保存できます。この記事では、異なる方法でプレゼンテーションを保存する方法を説明します。

## **ファイルにプレゼンテーションを保存**
[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスの[**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-)メソッドを呼び出すことで、プレゼンテーションをファイルに保存します。ファイル名と[**SaveFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SaveFormat)を[**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-)メソッドに渡します。

以下の例では、Aspose.Slides for Android via Javaを使用してプレゼンテーションを保存する方法を示します。

```java
// PPTファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation();
try {
    // ...ここで作業を行う...
    
    // プレゼンテーションをファイルに保存
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

## **ストリームにプレゼンテーションを保存**
出力ストリームを[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスの[**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.io.OutputStream-int-)メソッドに渡すことで、プレゼンテーションをストリームに保存することができます。プレゼンテーションを保存できるストリームの種類は多数あります。以下の例では、新しいプレゼンテーションファイルを作成し、シェイプにテキストを追加し、プレゼンテーションをストリームに保存しました。

```java
// PPTファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // シェイプにテキストを追加
    shape.getTextFrame().setText("このデモはPowerPointファイルを作成し、それをストリームに保存する方法を示しています。");

    OutputStream os = new FileOutputStream("Save_As_Stream_out.pptx");

    pres.save(os, com.aspose.slides.SaveFormat.Pptx);

    os.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **定義済みのビュータイプでプレゼンテーションを保存**
Aspose.Slides for Android via Javaは、プレゼンテーションがPowerPointで開かれた際にビュータイプを設定する機能を[ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties)クラスを通じて提供します。[**setLastView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#setLastView-int-)プロパティを使用して、[**ViewType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewType)列挙体を使用してビュータイプを設定します。

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
Aspose.Slidesでは、プレゼンテーションを厳密なOffice Open XML形式で保存できます。そのために、[**PptxOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions)クラスを提供しており、プレゼンテーションファイルを保存する際にConformanceプロパティを設定できます。値を[**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Conformance#Iso29500_2008_Strict)に設定すると、出力されるプレゼンテーションファイルは厳密なOpen XML形式で保存されます。

以下のサンプルコードは、プレゼンテーションを作成し、厳密なOffice Open XML形式で保存します。[**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)メソッドを呼び出す際に、[**PptxOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions)オブジェクトがConformanceプロパティを[**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Conformance#Iso29500_2008_Strict)に設定して渡されます。

```java
// PPTファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // ラインタイプのオートシェイプを追加
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

## **Zip64モードでOffice Open XML形式でプレゼンテーションを保存**

Office Open XMLファイルは、ファイルの未圧縮サイズ、圧縮サイズ、アーカイブの合計サイズについて4 GB（2^32バイト）の制限があるZIPアーカイブであり、アーカイブ内のファイル数については65,535（2^16-1）の制限があります。ZIP64形式の拡張機能は、制限を2^64に引き上げます。

新しい[**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/)プロパティを使用すると、保存されたOffice Open XMLファイルに対してZIP64形式の拡張機能を使用するかどうかを選択できます。

このプロパティは次のモードを提供します：

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#IfNecessary)は、プレゼンテーションが上記の制限を超えた場合にのみZIP64形式の拡張機能が使用されることを意味します。これがデフォルトモードです。
- [Zip64Mode.Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never)は、ZIP64形式の拡張機能が使用されないことを意味します。
- [Zip64Mode.Always](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Always)は、ZIP64形式の拡張機能が常に使用されることを意味します。

以下のコードは、ZIP64形式の拡張を使用してプレゼンテーションをPPTX形式で保存する方法を示しています：

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

Zip64Mode.Neverモードでの保存は、プレゼンテーションがZIP32形式で保存できない場合、[PptxException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxexception/)をスローします。

{{% /alert %}}

## **進捗状況の更新をパーセンテージで保存**
新しい[**IProgressCallback**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProgressCallback)インターフェースが[**ISaveOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISaveOptions)インターフェースと[**SaveOptions** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SaveOptions)抽象クラスに追加されました。[**IProgressCallback**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProgressCallback)インターフェースは、進捗状況の更新をパーセンテージで保存するためのコールバックオブジェクトを表します。  

以下のコードスニペットは、[IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProgressCallback)インターフェースの使い方を示しています：

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
        // ここで進捗のパーセンテージ値を使用
        int progress = Double.valueOf(progressValue).intValue();
        System.out.println(progress + "% ファイル変換済み");
    }
}
```

{{% alert title="情報" color="info" %}}

Asposeは独自のAPIを使用して、ユーザーがプレゼンテーションを複数のファイルに分割できる[無料のPowerPointスプリッターアプリ](https://products.aspose.app/slides/splitter)を開発しました。このアプリは、特定のプレゼンテーションから選択されたスライドを新しいPowerPoint（PPTXまたはPPT）ファイルとして保存します。

{{% /alert %}}