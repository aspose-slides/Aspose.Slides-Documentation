---
title: .NETでプレゼンテーションを保存
linktitle: プレゼンテーションを保存
type: docs
weight: 80
url: /ja/net/save-presentation/
keywords: "PowerPointを保存, PPT, PPTX, プレゼンテーションを保存, ファイル, ストリーム, C#, Csharp, .NET"
description: "C# または .NETで PowerPoint プレゼンテーションをファイルまたはストリームとして保存"
---

## **プレゼンテーションを保存**
プレゼンテーションを開く方法については、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスを使用してプレゼンテーションを開く方法を説明しています。この記事では、プレゼンテーションを作成し保存する方法を説明します。
[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスはプレゼンテーションの内容を保持します。最初からプレゼンテーションを作成する場合でも、既存のプレゼンテーションを変更する場合でも、完了したらプレゼンテーションを保存したくなるでしょう。Aspose.Slides for .NETを使用すると、**ファイル**または**ストリーム**として保存できます。この記事では、プレゼンテーションをさまざまな方法で保存する方法を説明します。

### **ファイルにプレゼンテーションを保存**
[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスの[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)メソッドを呼び出すことで、ファイルにプレゼンテーションを保存します。ファイル名と保存フォーマットを[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)メソッドに渡すだけです。以下の例は、C#を使用してAspose.Slides for .NETでプレゼンテーションを保存する方法を示しています。

```c#
// PPTファイルを表すPresentationオブジェクトをインスタンス化
Presentation presentation= new Presentation();

//...ここでいくつかの作業を行う...

// プレゼンテーションをファイルに保存
presentation.Save("Saved_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

### **ストリームにプレゼンテーションを保存**
出力ストリームを[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのSaveメソッドに渡すことで、プレゼンテーションをストリームに保存することができます。プレゼンテーションを保存できるストリームのタイプは多数あります。以下の例では、新しいプレゼンテーションファイルを作成し、シェイプにテキストを追加して、プレゼンテーションをストリームに保存しています。

```c#
// PPTファイルを表すPresentationオブジェクトをインスタンス化
using (Presentation presentation = new Presentation())
{

    IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // シェイプにテキストを追加
    shape.TextFrame.Text = "このデモでは、PowerPointファイルを作成し、それをストリームに保存する方法を示します。";

    FileStream toStream = new FileStream("Save_As_Stream_out.pptx", FileMode.Create);
    presentation.Save(toStream, Aspose.Slides.Export.SaveFormat.Pptx);
    toStream.Close();
}
```

### **既定のビュータイプでプレゼンテーションを保存**
Aspose.Slides for .NETは、[ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties)クラスを通じて、PowerPointで開いたときの生成されたプレゼンテーションのビュータイプを設定する機能を提供します。[LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/lastview)プロパティは、[ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype)列挙体を使用してビュータイプを設定するために使用されます。

```csharp
using (Presentation pres = new Presentation())
{
    pres.ViewProperties.LastView = ViewType.SlideMasterView;
    pres.Save("pres-will-open-SlideMasterView.pptx", SaveFormat.Pptx);
}
```

### **厳密なOffice Open XML形式でプレゼンテーションを保存**
Aspose.Slidesを使用すると、プレゼンテーションを厳密なOffice Open XML形式で保存できます。そのためには、プレゼンテーションファイルを保存する際にConformanceプロパティを設定できる[**Aspose.Slides.Export.PptxOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions)クラスが提供されています。その値をConformance.Iso29500_2008_Strictに設定すると、出力プレゼンテーションファイルは厳密なOffice Open XML形式で保存されます。

以下のサンプルコードは、プレゼンテーションを作成し、厳密なOffice Open XML形式で保存するものです。プレゼンテーションのSaveメソッドを呼び出す際に、**[Aspose.Slides.Export.PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions)**オブジェクトが渡され、[**Conformance**](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/properties/conformance)プロパティは[**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/net/aspose.slides.export/conformance)に設定されています。

```csharp
   // プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
   using (Presentation presentation = new Presentation())
   {
       // 最初のスライドを取得
       ISlide slide = presentation.Slides[0];

       // ラインタイプのオートシェイプを追加
       slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

       // プレゼンテーションを厳密なOffice Open XML形式で保存
       presentation.Save(dataDir + "NewPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx,
           new PptxOptions() { Conformance = Conformance.Iso29500_2008_Strict });

   }

```

### **Zip64モードでOffice Open XML形式のプレゼンテーションを保存**
Office Open XMLファイルはZIPアーカイブで、ファイルの未圧縮サイズ、圧縮サイズ、およびアーカイブの合計サイズに4GB（2^32バイト）の制限があり、アーカイブ内のファイル数も65,535（2^16-1）に制限されています。ZIP64形式の拡張により、これらの制限は2^64まで拡大されます。

新しい[**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/)プロパティを使用すると、保存されたOffice Open XMLファイルにZIP64形式の拡張を使用するかどうかを選択できます。

このプロパティは以下のモードを提供します：

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/)は、プレゼンテーションが上記の制限を超える場合のみZIP64形式の拡張が使用されることを意味します。これがデフォルトモードです。
- [Zip64Mode.Never](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/)は、ZIP64形式の拡張が使用されないことを意味します。 
- [Zip64Mode.Always](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/)は、ZIP64形式の拡張が常に使用されることを意味します。

以下のC#コードは、ZIP64形式の拡張を使用してプレゼンテーションをPPTX形式で保存する方法を示しています。

```c#
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-zip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="注意" color="warning" %}}

Zip64Mode.Neverモードで保存すると、プレゼンテーションがZIP32形式で保存できない場合に[PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/)がスローされます。

{{% /alert %}}

### **パーセンテージでの進捗更新の保存**
新しい[**IProgressCallback**](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback)インターフェースが[**ISaveOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions)インターフェースと[**SaveOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions)抽象クラスに追加されました。**IProgressCallback**インターフェースは、パーセンテージでの保存進捗更新のためのコールバックオブジェクトを表します。

以下のコードスニペットは、IProgressCallbackインターフェースの使用方法を示しています。

```c#
using (Presentation presentation = new Presentation("ConvertToPDF.pptx"))
{
    ISaveOptions saveOptions = new PdfOptions();
    saveOptions.ProgressCallback = new ExportProgressHandler();
    presentation.Save("ConvertToPDF.pdf", SaveFormat.Pdf, saveOptions);
}

```

```c#
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // 進捗のパーセンテージ値をここで使用
        int progress = Convert.ToInt32(progressValue);
        Console.WriteLine(progress + "%ファイルが変換されました");
    }
}
```

{{% alert title="情報" color="info" %}}

Asposeは独自のAPIを使用して、ユーザーがプレゼンテーションを複数のファイルに分割できる[無料のPowerPointスプリッターアプリ](https://products.aspose.app/slides/splitter)を開発しました。このアプリは、指定されたプレゼンテーションから選択したスライドを新しいPowerPoint（PPTXまたはPPT）ファイルとして保存します。 

{{% /alert %}}

<h2>プレゼンテーションを開いて保存</h2>

<a name="csharp-open-save-presentation"><strong>手順: C#でプレゼンテーションを開いて保存</strong></a>

1. 任意の形式（例: PPT, PPTX, ODPなど）で[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. プレゼンテーションを[SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)でサポートされている任意の形式で保存します。

```c#
// プレゼンテーションに任意のサポートされたファイルを読み込む（例: ppt, pptx, odpなど）
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```