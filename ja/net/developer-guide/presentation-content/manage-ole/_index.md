---
title: .NET でプレゼンテーション内の OLE オブジェクトを管理
linktitle: OLE を管理
type: docs
weight: 40
url: /ja/net/manage-ole/
keywords:
- OLE オブジェクト
- オブジェクト リンキングと埋め込み
- OLE を追加
- OLE を埋め込む
- オブジェクトを追加
- オブジェクトを埋め込む
- ファイルを追加
- ファイルを埋め込む
- リンクされたオブジェクト
- リンクされたファイル
- OLE を変更
- OLE アイコン
- OLE タイトル
- OLE を抽出
- オブジェクトを抽出
- ファイルを抽出
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument ファイルにおける OLE オブジェクトの管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---
## **紹介**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) は、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みにより別のアプリケーションに配置できる Microsoft の技術です。

{{% /alert %}} 

MS Excel で作成したグラフを考えてみてください。そのグラフを PowerPoint のスライドに配置した場合、Excel のグラフは OLE オブジェクトと見なされます。

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、関連付けられたアプリケーション (Excel) でグラフが開かれるか、オブジェクトの開閉や編集に使用するアプリケーションの選択を求められます。
- OLE オブジェクトは実際の内容 (例えばグラフの内容) を表示することもあります。この場合、PowerPoint 内でグラフが有効化され、グラフのインターフェイスが読み込まれ、PowerPoint 上でグラフのデータを変更できます。

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) を使用すると、OLE オブジェクトを OLE オブジェクトフレーム ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)) としてスライドに挿入できます。

## **スライドへのOLEオブジェクトフレームの追加**

Microsoft Excel で既にグラフを作成し、Aspose.Slides for .NET を使用して OLE オブジェクトフレームとしてスライドに埋め込みたい場合、以下の手順で行えます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. Excel ファイルをバイト配列として読み取ります。  
4. バイト配列と OLE オブジェクトに関するその他の情報を含む [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) をスライドに追加します。  
5. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、Excel ファイルからグラフを取得し、Aspose.Slides for .NET を使用して [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) としてスライドに追加しました。  
**注意** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) コンストラクタは、第二引数として埋め込み可能オブジェクトの拡張子を受け取ります。この拡張子により、PowerPoint はファイルタイプを正しく解釈し、適切なアプリケーションで OLE オブジェクトを開くことができます。

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // OLE オブジェクトのデータを準備します。
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // スライドに OLE オブジェクトフレームを追加します。
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **リンクされたOLEオブジェクトフレームの追加**

Aspose.Slides for .NET を使用すると、データを埋め込まずにファイルへのリンクだけで [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) を追加できます。

以下の C# コードは、リンクされた Excel ファイルを使用してスライドに [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) を追加する方法を示しています。

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // リンクされた Excel ファイルを使用して OLE オブジェクトフレームを追加します。
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **OLEオブジェクトフレームへのアクセス**

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順で簡単に検索またはアクセスできます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成して、埋め込み OLE オブジェクトを含むプレゼンテーションをロードします。  
2. インデックスを使用してスライドの参照を取得します。  
3. [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) シェイプにアクセスします。  
   この例では、最初のスライドに 1 つだけシェイプがある先ほど作成した PPTX を使用しました。そのシェイプを [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) として *cast* しました。これがアクセス対象の OLE オブジェクトフレームです。  
4. OLE オブジェクトフレームにアクセスできたら、任意の操作を実行できます。

以下の例では、スライドに埋め込まれた OLE オブジェクトフレーム (Excel のグラフオブジェクト) とそのファイルデータにアクセスしています。

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 最初のシェイプを OLE オブジェクトフレームとして取得します。
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // 埋め込まれたファイルデータを取得します。
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // 埋め込まれたファイルの拡張子を取得します。
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **リンクされたOLEオブジェクトフレームのプロパティへのアクセス**

Aspose.Slides を使用すると、リンクされた OLE オブジェクトフレームのプロパティにアクセスできます。

この C# コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンク先ファイルのパスを取得する方法を示しています。

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // 最初のシェイプを OLE オブジェクトフレームとして取得します。
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // OLE オブジェクトがリンクされているか確認します。
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // リンクされたファイルへのフルパスを表示します。
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // 存在する場合、リンクされたファイルへの相対パスを表示します。
        // 相対パスを含められるのは PPT プレゼンテーションだけです。
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **OLEオブジェクトデータの変更**

{{% alert color="info" title="Note" %}}

このセクションでは、以下のコード例で [Aspose.Cells for .NET](https://docs.aspose.com/cells/net/) を使用しています。

{{% /alert %}}

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順でオブジェクトにアクセスし、データを変更できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成して、埋め込み OLE オブジェクトを含むプレゼンテーションをロードします。  
2. インデックスを使用してスライドの参照を取得します。  
3. [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) シェイプにアクセスします。  
   この例では、最初のスライドに 1 つのシェイプがある PPTX を使用しました。そのシェイプを [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) として *cast* しました。これがアクセス対象の OLE オブジェクトフレームです。  
4. OLE オブジェクトフレームにアクセスできたら、任意の操作を実行できます。  
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。  
6. 対象の `Worksheet` にアクセスし、データを修正します。  
7. 更新した `Workbook` をストリームに保存します。  
8. ストリームから OLE オブジェクトデータを変更します。

以下の例では、スライドに埋め込まれた OLE オブジェクトフレーム (Excel のグラフオブジェクト) にアクセスし、ファイルデータを変更してグラフデータを更新しています。

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 最初のシェイプを OLE オブジェクトフレームとして取得します。
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // OLE オブジェクトデータを Workbook オブジェクトとして読み取ります。
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // ワークブックデータを変更します。
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // OLE フレームオブジェクトデータを変更します。
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **スライドへの他のファイルタイプの埋め込み**

Excel のグラフ以外にも、Aspose.Slides for .NET を使用すると、HTML、PDF、ZIP などのさまざまなファイルをスライドに埋め込むことができます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連プログラムで自動的に開くか、適切なプログラムの選択を促すダイアログが表示されます。

以下の C# コードは、HTML と ZIP をスライドに埋め込む方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

この C# コードは、埋め込み OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

OLE オブジェクトを埋め込むと、アイコン画像からなるプレビューが自動的に追加されます。これはユーザーがオブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビューの要素として使用したい場合、Aspose.Slides for .NET を使用してアイコン画像とタイトルを設定できます。

以下の C# コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **OLEオブジェクトフレームのサイズ変更と再配置の防止**

リンクされた OLE オブジェクトをプレゼンテーションのスライドに追加した後、PowerPoint でプレゼンテーションを開くと「リンクの更新」メッセージが表示されることがあります。 「Update Links」ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトのデータを更新し、プレビューを再描画するため、OLE オブジェクトフレームのサイズと位置が変更される場合があります。 PowerPoint がオブジェクトのデータ更新を促さないようにするには、[IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) インターフェイスの `UpdateAutomatic` プロパティを `false` に設定します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // PowerPoint がリンクを更新するときに OLE オブジェクトフレームのサイズと位置を保持します。
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **埋め込みファイルの抽出**

Aspose.Slides for .NET を使用すると、スライドに OLE オブジェクトとして埋め込まれたファイルを次の手順で抽出できます。

1. 抽出対象の OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. プレゼンテーション内のすべてのシェイプをループし、[OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) シェイプにアクセスします。  
3. OLE オブジェクトフレームから埋め込みファイルのデータにアクセスし、ディスクに書き出します。

以下の C# コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています。

```c#
using Aspose.Slides;

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

**スライドを PDF/画像にエクスポートするときに OLE コンテンツはレンダリングされますか？**

スライド上に表示されるのはアイコン/代替画像 (プレビュー) です。「ライブ」な OLE コンテンツはレンダリング時に実行されません。必要に応じて、期待通りの外観になるようプレビュー画像を自分で設定してください。

埋め込みファイルを PDF の添付ファイルとしても保持したい場合は、[PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) を `true` に設定します。このオプションは既定で無効です。サンプルと添付ファイルの確認手順は、[Preserve Embedded OLE Files as PDF Attachments](/slides/ja/net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) を参照してください。

**スライド上の OLE オブジェクトをロックして、ユーザーが PowerPoint で移動/編集できないようにするには？**

シェイプをロックします。Aspose.Slides は [shape-level locks](/slides/ja/net/applying-protection-to-presentation/) を提供しています。これは暗号化ではありませんが、誤操作による編集や移動を実質的に防止します。

**リンクされた Excel オブジェクトを開くと「ジャンプ」したりサイズが変わったりするのはなぜですか？**

PowerPoint はリンクされた OLE のプレビューを更新することがあります。安定した外観を保つには、[Working Solution for Worksheet Resizing](/slides/ja/net/working-solution-for-worksheet-resizing/) の手順に従い、フレームを範囲に合わせるか、範囲を固定フレームにスケーリングし、適切な代替画像を設定してください。

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**

PPTX では「相対パス」情報は利用できず、フルパスのみが保存されます。相対パスは古い PPT 形式でのみ利用可能です。可搬性を高めるには、信頼できる絶対パスまたはアクセス可能な URI、あるいは埋め込みを使用してください。