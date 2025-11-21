---
title: .NET でプレゼンテーションの OLE オブジェクトを管理する
linktitle: OLE の管理
type: docs
weight: 40
url: /ja/net/manage-ole/
keywords:
- OLE オブジェクト
- オブジェクト リンキング & 埋め込み
- OLE の追加
- OLE の埋め込み
- オブジェクトの追加
- オブジェクトの埋め込み
- ファイルの追加
- ファイルの埋め込み
- リンクされたオブジェクト
- リンクされたファイル
- OLE の変更
- OLE アイコン
- OLE タイトル
- OLE の抽出
- オブジェクトの抽出
- ファイルの抽出
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument ファイルの OLE オブジェクト管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---

{{% alert title="Info" color="info" %}}

OLE（Object Linking & Embedding）は、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みにより別のアプリケーションに配置できる Microsoft の技術です。

{{% /alert %}}

たとえば、MS Excel で作成したチャートを考えてみます。そのチャートを PowerPoint のスライドに配置します。この Excel のチャートは OLE オブジェクトと見なされます。

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、チャートが関連付けられたアプリケーション（Excel）で開かれるか、オブジェクトを開くまたは編集するアプリケーションの選択を求められます。
- OLE オブジェクトは実際の内容（例えばチャートの内容）を表示することもあります。この場合、PowerPoint 内でチャートがアクティブになり、チャートのインターフェイスがロードされ、PowerPoint 上でチャートのデータを変更できます。

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) を使用すると、スライドに OLE オブジェクトを OLE オブジェクト フレームとして挿入できます（[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)）。

## **スライドへの OLE オブジェクト フレームの追加**

Microsoft Excel で既にチャートを作成し、Aspose.Slides for .NET を使用して OLE オブジェクト フレームとしてスライドに埋め込みたい場合、次の手順で行えます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. Excel ファイルをバイト配列として読み取ります。
4. バイト配列および OLE オブジェクトに関するその他の情報を含む [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) をスライドに追加します。
5. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、Excel ファイルからチャートを取得し、Aspose.Slides for .NET を使用してスライドに [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) として追加しています。**注**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) コンストラクタは第2パラメータとして埋め込み可能オブジェクトの拡張子を受け取ります。この拡張子により、PowerPoint はファイルタイプを正しく解釈し、適切なアプリケーションでこの OLE オブジェクトを開くことができます。

```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // OLE オブジェクト用のデータを準備します。
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // スライドに OLE オブジェクト フレームを追加します。
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


### **リンクされた OLE オブジェクト フレームの追加**

Aspose.Slides for .NET を使用すると、データを埋め込まずにファイルへのリンクだけで [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) を追加できます。

以下の C# コードは、リンクされた Excel ファイルを使用してスライドに [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) を追加する方法を示しています。

```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // リンクされた Excel ファイルで OLE オブジェクト フレームを追加します。
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **OLE オブジェクト フレームへのアクセス**

スライドに OLE オブジェクトがすでに埋め込まれている場合、次の手順で簡単に検索またはアクセスできます。

1. 埋め込まれた OLE オブジェクトを含むプレゼンテーションを、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成してロードします。
2. インデックスを使用して対象スライドの参照を取得します。
3. [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) シェイプにアクセスします。例では、最初のスライドに 1 つだけシェイプがある先に作成した PPTX を使用しました。そのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) に *キャスト* しました。これがアクセス対象の OLE オブジェクト フレームです。
4. OLE オブジェクト フレームにアクセスできたら、任意の操作を実行できます。

以下の例では、OLE オブジェクト フレーム（スライドに埋め込まれた Excel チャート オブジェクト）とそのファイルデータにアクセスしています。

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 最初のシェイプを OLE オブジェクト フレームとして取得します。
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // 埋め込まれたファイルデータを取得します。
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // 埋め込みファイルの拡張子を取得します。
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```


### **リンクされた OLE オブジェクト フレーム プロパティへのアクセス**

Aspose.Slides を使用すると、リンクされた OLE オブジェクト フレームのプロパティにアクセスできます。

以下の C#コードは、OLE オブジェクトがリンクされているかを確認し、リンク先ファイルのパスを取得する方法を示しています。

```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // 最初のシェイプを OLE オブジェクト フレームとして取得します。
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // OLE オブジェクトがリンクされているか確認します。
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // リンクされたファイルへのフルパスを出力します。
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // 存在する場合、リンクされたファイルへの相対パスを出力します。
        // 相対パスを含められるのは PPT プレゼンテーションだけです。
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```


## **OLE オブジェクト データの変更**

{{% alert color="primary" %}} 
このセクションでは、以下のコード例で [Aspose.Cells for .NET](/cells/net/) を使用しています。
{{% /alert %}}

スライドに OLE オブジェクトがすでに埋め込まれている場合、次の手順でそのオブジェクトにアクセスしデータを変更できます。

1. 埋め込まれた OLE オブジェクトを含むプレゼンテーションを、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成してロードします。
2. インデックスを使用して対象スライドの参照を取得します。
3. [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) シェイプにアクセスします。例では、最初のスライドに 1 つのシェイプがある先に作成した PPTX を使用しました。そのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) に *キャスト* しました。これがアクセス対象の OLE オブジェクト フレームです。
4. OLE オブジェクト フレームにアクセスできたら、任意の操作を実行できます。
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。
6. 対象の `Worksheet` にアクセスし、データを修正します。
7. 更新した `Workbook` をストリームに保存します。
8. ストリームから OLE オブジェクト データを変更します。

以下の例では、OLE オブジェクト フレーム（スライドに埋め込まれた Excel チャート オブジェクト）にアクセスし、ファイルデータを変更してチャート データを更新しています。

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 最初のシェイプを OLE オブジェクト フレームとして取得します。
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // OLE オブジェクト データを Workbook オブジェクトとして読み取ります。
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Workbook のデータを変更します。
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // OLE フレーム オブジェクトのデータを変更します。
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **スライドへの他のファイルタイプの埋め込み**

Excel チャートに加えて、Aspose.Slides for .NET を使用すると、スライドに他の種類のファイルを埋め込むことができます。たとえば、HTML、PDF、ZIP ファイルをオブジェクトとして挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連するプログラムで自動的に開くか、開くプログラムの選択が求められます。

以下の C# コードは、HTML と ZIP をスライドに埋め込む方法を示しています。

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **埋め込みオブジェクトのファイルタイプ設定**

プレゼンテーションを操作する際、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされているものに置き換える必要がある場合があります。Aspose.Slides for .NET を使用すると、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレームのデータや拡張子を更新できます。

以下の C# コードは、埋め込み OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています。

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // ファイルタイプを ZIP に変更します。
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **埋め込みオブジェクトのアイコン画像とタイトルの設定**

OLE オブジェクトを埋め込むと、自動的にアイコン画像で構成されたプレビューが追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビュー要素として使用したい場合、Aspose.Slides for .NET を使用してアイコン画像とタイトルを設定できます。

以下の C# コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています。

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // プレゼンテーションのリソースに画像を追加します。
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // OLE プレビュー用にタイトルと画像を設定します。
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **OLE オブジェクト フレームがサイズ変更や位置変更されるのを防止する**

リンクされた OLE オブジェクトをプレゼンテーション スライドに追加した後、PowerPoint でプレゼンテーションを開くと、リンクの更新を求めるメッセージが表示されることがあります。「Update Links」ボタンをクリックすると、リンクされた OLE オブジェクトからデータが更新され、オブジェクトのプレビューが再描画されるため、OLE オブジェクト フレームのサイズや位置が変わることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) インターフェイスの `UpdateAutomatic` プロパティを `false` に設定します：

```cs
oleFrame.UpdateAutomatic = false;
```


## **埋め込みファイルの抽出**

Aspose.Slides for .NET を使用すると、スライドに OLE オブジェクトとして埋め込まれたファイルを次の手順で抽出できます。

1. 抽出したい OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのシェイプをループし、[OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) シェイプにアクセスします。
3. OLE オブジェクト フレームから埋め込みファイルのデータにアクセスし、ディスクに書き出します。

以下の C# コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています。

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```


## **FAQ**

**スライドを PDF/画像 にエクスポートしたとき、OLE コンテンツはレンダリングされますか？**

スライド上に表示されているもの、すなわちアイコン/代替画像（プレビュー）がレンダリングされます。実際の OLE コンテンツはレンダリング時に実行されません。必要に応じて、期待通りの外観になるようプレビュー画像を自前で設定してください。

**スライド上の OLE オブジェクトをロックし、PowerPoint でユーザーが移動/編集できないようにするには？**

シェイプをロックします。Aspose.Slides は [shape-level locks](/slides/ja/net/applying-protection-to-presentation/) を提供しています。暗号化ではありませんが、誤って編集や移動されるのを実質的に防止できます。

**リンクされた Excel オブジェクトがプレゼンテーションを開くと「ジャンプ」したりサイズが変わったりするのはなぜですか？**

PowerPoint はリンクされた OLE のプレビューを更新することがあります。安定した表示を得るには、[Working Solution for Worksheet Resizing](/slides/ja/net/working-solution-for-worksheet-resizing/) の手順に従ってください。フレームを範囲に合わせるか、範囲を固定フレームにスケーリングし、適切な代替画像を設定します。

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**

PPTX では「相対パス」情報は保持されず、フルパスのみが保存されます。相対パスは古い PPT 形式でのみ利用可能です。ポータビリティを考えるなら、信頼できる絶対パスやアクセス可能な URI、あるいは埋め込みを使用してください。