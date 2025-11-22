---
title: C# を使用したプレゼンテーションの OLE 管理
linktitle: OLE の管理
type: docs
weight: 40
url: /ja/net/manage-ole/
keywords:
- OLE オブジェクト
- オブジェクト リンキングとエンベディング
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
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument ファイル内の OLE オブジェクト管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---

{{% alert title="Info" color="info" %}}

OLE（Object Linking & Embedding）は、あるアプリケーションで作成したデータやオブジェクトを、リンクまたは埋め込みにより別のアプリケーションに配置できる Microsoft の技術です。

{{% /alert %}} 

Microsoft Excel で作成したチャートを考えてみてください。そのチャートを PowerPoint のスライドに配置します。この Excel のチャートは OLE オブジェクトと見なされます。

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、チャートは関連付けられたアプリケーション（Excel）で開かれるか、オブジェクトの開閉や編集に使用するアプリケーションの選択を求められます。
- OLE オブジェクトは実際の内容（たとえばチャートの内容）を表示することもあります。この場合、PowerPoint 内でチャートがアクティブになり、チャート インターフェイスがロードされ、PowerPoint 上でチャートのデータを変更できます。

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) を使用すると、スライドに OLE オブジェクトを OLE オブジェクト フレーム（[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)）として挿入できます。

## **Adding OLE Object Frames to Slides**

Microsoft Excel で既にチャートを作成し、Aspose.Slides for .NET を使用して OLE オブジェクト フレームとしてスライドに埋め込みたい場合、次の手順で実行できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. Excel ファイルをバイト配列として読み取ります。  
4. バイト配列と OLE オブジェクトに関するその他の情報を含む [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) をスライドに追加します。  
5. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、Excel ファイルからチャートを取得し、Aspose.Slides for .NET を使用して [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) としてスライドに追加しています。  
**Note** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) のコンストラクタは、2 番目のパラメータとして埋め込み可能なオブジェクト拡張子を受け取ります。この拡張子により、PowerPoint はファイルタイプを正しく解釈し、適切なアプリケーションで OLE オブジェクトを開くことができます。
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


### **Adding Linked OLE Object Frames**

Aspose.Slides for .NET を使用すると、データを埋め込まずにファイルへのリンクだけで [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) を追加できます。

以下の C# コードは、リンクされた Excel ファイルを使用してスライドに [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) を追加する方法を示しています。
```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // リンクされた Excel ファイルを使用した OLE オブジェクト フレームを追加します。
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Accessing OLE Object Frames**

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順で簡単に検索または取得できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) シェイプにアクセスします。  
   例では、最初のスライドに 1 つだけシェイプがある既存の PPTX を使用しました。そのシェイプを [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) に *cast* して、目的の OLE オブジェクト フレームを取得しました。  
4. OLE オブジェクト フレームにアクセスできたら、任意の操作を実行できます。

以下の例では、OLE オブジェクト フレーム（スライドに埋め込まれた Excel チャート オブジェクト）とそのファイル データにアクセスしています。
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 最初のシェイプを OLE オブジェクト フレームとして取得します。
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // 埋め込みファイル データを取得します。
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // 埋め込みファイルの拡張子を取得します。
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```


### **Accessing Linked OLE Object Frame Properties**

Aspose.Slides を使用すると、リンクされた OLE オブジェクト フレームのプロパティにアクセスできます。

以下の C# コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンク先ファイルへのパスを取得する方法を示しています。
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

        // リンクされたファイルへの相対パスがある場合に出力します。
        // 相対パスは PPT プレゼンテーションにのみ含まれます。
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```


## **Changing OLE Object Data**

{{% alert color="primary" %}} 

このセクションでは、以下のコード例で [Aspose.Cells for .NET](/cells/net/) を使用しています。

{{% /alert %}}

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順でオブジェクトにアクセスしデータを変更できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) シェイプにアクセスします。  
   例では、最初のスライドに 1 つだけシェイプがある PPTX を使用し、そのシェイプを [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) に *cast* して目的のフレームを取得しました。  
4. OLE オブジェクト フレームにアクセスできたら、任意の操作を実行できます。  
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。  
6. 目的の `Worksheet` にアクセスし、データを修正します。  
7. 更新された `Workbook` をストリームに保存します。  
8. ストリームから OLE オブジェクト データを変更します。

以下の例では、OLE オブジェクト フレーム（スライドに埋め込まれた Excel チャート オブジェクト）にアクセスし、ファイル データを変更してチャート データを更新しています。
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // OLE オブジェクト フレームとして最初のシェイプを取得します。
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


## **Embedding Other File Types in Slides**

Excel チャート以外にも、Aspose.Slides for .NET を使用すると、HTML、PDF、ZIP などの他のファイル形式をスライドに埋め込むことができます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連するプログラムで自動的に開くか、適切なプログラムを選択するように求められます。

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


## **Setting File Types for Embedded Objects**

プレゼンテーションで作業する際、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされているものに置き換えたりする必要がある場合があります。Aspose.Slides for .NET を使用すると、埋め込みオブジェクトのファイル タイプを設定でき、OLE フレーム データや拡張子を更新できます。

以下の C# コードは、埋め込まれた OLE オブジェクトのファイル タイプを `zip` に設定する方法を示しています。
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


## **Setting Icon Images and Titles for Embedded Objects**

OLE オブジェクトを埋め込むと、アイコン画像からなるプレビューが自動的に追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビューに使用したい場合、Aspose.Slides for .NET を使用してアイコン画像とタイトルを設定できます。

以下の C# コードは、埋め込まれたオブジェクトのアイコン画像とタイトルを設定する方法を示しています。
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


## **Prevent an OLE Object Frame from Being Resized and Pepositioned**

リンクされた OLE オブジェクトをプレゼンテーション スライドに追加した後、PowerPoint でプレゼンテーションを開くと、リンクの更新を求めるメッセージが表示されることがあります。「Update Links」ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトからデータを更新し、プレビューを再描画するため、OLE オブジェクト フレームのサイズや位置が変更されることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) インターフェイスの `UpdateAutomatic` プロパティを `false` に設定します。
```cs
oleFrame.UpdateAutomatic = false;
```


## **Extracting Embedded Files**

Aspose.Slides for .NET を使用すると、スライドに OLE オブジェクトとして埋め込まれたファイルを次の手順で抽出できます。

1. 埋め込まれた OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. プレゼンテーション内のすべてのシェイプをループし、[OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) シェイプにアクセスします。  
3. OLE オブジェクト フレームから埋め込みファイルのデータを取得し、ディスクに書き出します。

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

**Will the OLE content be rendered when exporting slides to PDF/images?**

スライドに表示されているものがレンダリングされます—アイコンや代替画像（プレビュー）です。「ライブ」な OLE コンテンツはレンダリング時に実行されません。必要に応じて独自のプレビュー画像を設定し、エクスポートされた PDF で期待通りの外観になるようにしてください。

**How can I lock an OLE object on a slide so users cannot move/edit it in PowerPoint?**

シェイプをロックします。Aspose.Slides は [shape-level locks](/slides/ja/net/applying-protection-to-presentation/) を提供しています。これは暗号化ではありませんが、誤って編集や移動されるのを実質的に防止します。

**Why does a linked Excel object "jump" or change size when I open the presentation?**

PowerPoint がリンクされた OLE のプレビューを更新するためです。安定した外観を保つには、[Working Solution for Worksheet Resizing](/slides/ja/net/working-solution-for-worksheet-resizing/) の手順に従い、フレームを範囲に合わせるか、範囲を固定フレームに合わせて適切な代替画像を設定してください。

**Will relative paths for linked OLE objects be preserved in the PPTX format?**

PPTX 形式では「相対パス」情報は保持されず、フル パスのみが保存されます。相対パスは古い PPT 形式でのみ利用可能です。ポータビリティを確保するには、信頼できる絶対パスまたはアクセス可能な URI、または埋め込みを使用することを推奨します。