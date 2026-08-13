---
title: ".NET でプレゼンテーションの OLE オブジェクトを管理"
linktitle: "OLE の管理"
type: docs
weight: 40
url: /ja/net/manage-ole/
keywords:
- OLE オブジェクト
- オブジェクトのリンクと埋め込み
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
## **Introduction**

{{% alert title="Info" color="info" %}}
OLE（Object Linking & Embedding）は、Microsoft のテクノロジーで、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みにより別のアプリケーションに配置できるようにします。  
{{% /alert %}} 

MS Excel で作成したチャートを考えてみてください。そのチャートを PowerPoint のスライドに配置すると、Excel のチャートは OLE オブジェクトとみなされます。 

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックするとチャートが関連付けられたアプリケーション（Excel）で開かれるか、オブジェクトの開閉または編集に使用するアプリケーションの選択を求められます。 
- OLE オブジェクトはチャートの内容など、実際のコンテンツを表示することもあります。この場合、PowerPoint 内でチャートがアクティブになり、チャート インターフェイスがロードされ、PowerPoint 上でチャート データを変更できます。

[Aspose.Slides for .NET](https://products.aspose.com/slides/ja/net/) を使用すると、OLE オブジェクトをスライドに OLE オブジェクト フレーム（[OleObjectFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/oleobjectframe)）として挿入できます。

## **スライドに OLE オブジェクト フレームを追加**

Microsoft Excel で既にチャートを作成し、Aspose.Slides for .NET を使用して OLE オブジェクト フレームとしてスライドに埋め込みたい場合、次の手順で行えます。

1. Presentation クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. Excel ファイルをバイト配列として読み取ります。  
4. バイト配列および OLE オブジェクトに関するその他の情報を含む OleObjectFrame をスライドに追加します。  
5. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

以下の例では、Excel ファイルからチャートを取得し、Aspose.Slides for .NET を使用して OleObjectFrame としてスライドに追加しました。**注**: OleEmbeddedDataInfo のコンストラクタは、2 番目のパラメータとして埋め込み可能オブジェクトの拡張子を受け取ります。この拡張子により、PowerPoint はファイルタイプを正しく解釈し、この OLE オブジェクトを開く適切なアプリケーションを選択できます。

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

    // スライドに OLE オブジェクト フレームを追加します。
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **リンクされた OLE オブジェクト フレームの追加**

Aspose.Slides for .NET を使用すると、データを埋め込まず、ファイルへのリンクのみで OleObjectFrame を追加できます。

以下の C# コードは、リンクされた Excel ファイルを使用して OleObjectFrame をスライドに追加する方法を示しています：

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // リンクされた Excel ファイルで OLE オブジェクト フレームを追加します。
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **OLE オブジェクト フレームへのアクセス**

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順で簡単に検索またはアクセスできます。

1. Presentation クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションをロードします。  
2. インデックスを使用してスライドの参照を取得します。  
3. OleObjectFrame シェイプにアクセスします。例では、最初のスライドに 1 つだけシェイプがある先に作成した PPTX を使用しました。そのオブジェクトを *cast* して IOleObjectFrame として扱います。これがアクセス対象の OLE オブジェクト フレームです。  
4. OLE オブジェクト フレームにアクセスできたら、任意の操作を実行できます。  

以下の例では、OLE オブジェクト フレーム（スライドに埋め込まれた Excel チャート オブジェクト）とそのファイル データにアクセスしています。

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // OLE オブジェクト フレームとして最初のシェイプを取得します。
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // 埋め込まれたファイル データを取得します。
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // 埋め込まれたファイルの拡張子を取得します。
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **リンクされた OLE オブジェクト フレームのプロパティへのアクセス**

Aspose.Slides を使用すると、リンクされた OLE オブジェクト フレームのプロパティにアクセスできます。

以下の C# コードは、OLE オブジェクトがリンクされているか確認し、リンク先ファイルのパスを取得する方法を示しています：

```csharp
using Aspose.Slides;

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
        // 相対パスを含めることができるのは PPT プレゼンテーションのみです。
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **OLE オブジェクト データの変更**

{{% alert color="info" %}}  
このセクションでは、以下のコード例で [Aspose.Cells for .NET](/cells/net/) を使用しています。  
{{% /alert %}}

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順でオブジェクトにアクセスし、データを変更できます。

1. Presentation クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションをロードします。  
2. インデックスを使用してスライドの参照を取得します。  
3. OLEObjectFrame シェイプにアクセスします。例では、最初のスライドに 1 つのシェイプがある先に作成した PPTX を使用しました。そのオブジェクトを *cast* して IOleObjectFrame として扱います。これがアクセス対象の OLE オブジェクト フレームです。  
4. OLE オブジェクト フレームにアクセスできたら、任意の操作を実行できます。  
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。  
6. 目的の `Worksheet` にアクセスし、データを修正します。  
7. 更新した `Workbook` をストリームに保存します。  
8. ストリームから OLE オブジェクトのデータを変更します。  

以下の例では、OLE オブジェクト フレーム（スライドに埋め込まれた Excel チャート オブジェクト）にアクセスし、ファイル データを変更してチャート データを更新しています。

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Workbook のデータを変更します。
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // OLE フレームのオブジェクトデータを変更します。
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **スライドに他のファイルタイプを埋め込む**

Excel チャートに加えて、Aspose.Slides for .NET はスライドに他の種類のファイルを埋め込むことも可能です。たとえば、HTML、PDF、ZIP ファイルをオブジェクトとして挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連プログラムで自動的に開くか、適切なプログラムの選択を求められます。

以下の C# コードは、HTML と ZIP をスライドに埋め込む方法を示しています：

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

## **埋め込みオブジェクトのファイルタイプを設定**

プレゼンテーションを操作する際、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされたものに置き換える必要がある場合があります。Aspose.Slides for .NET を使用すると、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレームのデータや拡張子を更新できます。

以下の C# コードは、埋め込み OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています：

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

## **埋め込みオブジェクトのアイコン画像とタイトルを設定**

OLE オブジェクトを埋め込むと、アイコン画像からなるプレビューが自動的に追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビューに使用したい場合は、Aspose.Slides for .NET を使用してアイコン画像とタイトルを設定できます。

以下の C# コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています： 

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

## **OLE オブジェクト フレームがサイズ変更や位置変更されるのを防止**

リンクされた OLE オブジェクトをプレゼンテーション スライドに追加した後、PowerPoint でプレゼンテーションを開くと、リンクの更新を求めるメッセージが表示されることがあります。「Update Links」ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトのデータを更新し、オブジェクト プレビューをリフレッシュするため、OLE オブジェクト フレームのサイズや位置が変更されることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[IOleObjectFrame] インターフェイスの `UpdateAutomatic` プロパティを `false` に設定します：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // PowerPoint がリンクを更新するときに OLE オブジェクト フレームのサイズと位置を保持します。
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **埋め込みファイルの抽出**

Aspose.Slides for .NET を使用すると、スライドに埋め込まれたファイルを OLE オブジェクトとして次の手順で抽出できます。

1. 抽出したい OLE オブジェクトを含む Presentation クラスのインスタンスを作成します。  
2. プレゼンテーション内のすべてのシェイプをループし、OLEObjectFrame シェイプにアクセスします。  
3. OLE オブジェクト フレームから埋め込みファイルのデータにアクセスし、ディスクに書き込みます。  

以下の C# コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています：

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

### スライドを PDF/画像 にエクスポートする際、OLE コンテンツはレンダリングされますか？

スライド上に表示されているもの（アイコン/代替画像（プレビュー））がレンダリングされます。ライブの OLE コンテンツはレンダリング時に実行されません。必要に応じて、独自のプレビュー画像を設定して、エクスポートされた PDF で期待通りの外観になるようにしてください。

### スライド上の OLE オブジェクトをロックして、PowerPoint でユーザーが移動/編集できないようにするには？

シェイプをロックします。Aspose.Slides は [shape-level locks](/slides/ja/net/applying-protection-to-presentation/) を提供しています。これは暗号化ではありませんが、誤って編集や移動することを実質的に防止します。

### リンクされた Excel オブジェクトをプレゼンテーションで開くと「ジャンプ」したりサイズが変わるのはなぜですか？

PowerPoint がリンクされた OLE のプレビューを更新することがあります。安定した外観を保つには、[Worksheet Resizing の実践的な解決策](/slides/ja/net/working-solution-for-worksheet-resizing/) に従い、フレームを範囲に合わせるか、範囲を固定フレームにスケールし、適切な代替画像を設定してください。

### PPTX 形式でリンクされた OLE オブジェクトの相対パスは保持されますか？

PPTX では「相対パス」情報は保持されず、フルパスのみが保存されます。相対パスは旧来の PPT 形式で利用可能です。移植性を考慮する場合は、信頼できる絶対パスまたはアクセス可能な URI、あるいは埋め込みを使用してください。