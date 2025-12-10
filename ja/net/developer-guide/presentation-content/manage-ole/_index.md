---
title: .NET でプレゼンテーションの OLE オブジェクトを管理
linktitle: OLE の管理
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
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument ファイルの OLE オブジェクト管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---

{{% alert title="Info" color="info" %}}

OLE（Object Linking & Embedding）は、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みを通じて別のアプリケーションに配置できる Microsoft の技術です。

{{% /alert %}} 

Excel で作成したチャートを考えてみましょう。そのチャートが PowerPoint のスライドに配置されます。この Excel チャートは OLE オブジェクトと見なされます。

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックするとチャートは関連付けられたアプリケーション（Excel）で開かれるか、オブジェクトの開閉や編集に使用するアプリケーションを選択するよう求められます。
- OLE オブジェクトはチャートの内容そのものを表示することがあります。この場合、PowerPoint でチャートがアクティブになり、チャートインターフェイスが読み込まれ、PowerPoint 内でチャートのデータを変更できます。

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) を使用すると、スライドに OLE オブジェクトを OLE オブジェクト フレーム（[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)）として挿入できます。

## **スライドへの OLE オブジェクト フレームの追加**

Microsoft Excel で既にチャートを作成し、Aspose.Slides for .NET を使用して OLE オブジェクト フレームとしてスライドに埋め込みたい場合、以下の手順で実行できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. Excel ファイルをバイト配列として読み取ります。
4. バイト配列および OLE オブジェクトに関するその他の情報を含む [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) をスライドに追加します。
5. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、Excel ファイルからチャートを取得し、Aspose.Slides for .NET を使用して [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) としてスライドに追加しました。  
**注**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) コンストラクタは、2 番目のパラメータとして埋め込み可能なオブジェクト拡張子を受け取ります。この拡張子により PowerPoint はファイルタイプを正しく解釈し、適切なアプリケーションで OLE オブジェクトを開くことができます。
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

以下の C# コードは、リンクされた Excel ファイルを持つ [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) をスライドに追加する方法を示します:
```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // リンクされた Excel ファイルを使用して OLE オブジェクト フレームを追加します。
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **OLE オブジェクト フレームへのアクセス**

スライドに OLE オブジェクトが既に埋め込まれている場合、以下の手順で簡単に見つけたりアクセスしたりできます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションを読み込みます。
2. インデックスを使用してスライドの参照を取得します。
3. [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) シェイプにアクセスします。例では、最初のスライドに 1 つだけシェイプがある PPTX を使用し、そのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) として *キャスト* しています。これが目的の OLE オブジェクト フレームです。
4. OLE オブジェクト フレームにアクセスできたら、任意の操作を実行できます。

以下の例では、スライドに埋め込まれた OLE オブジェクト フレーム（Excel チャートオブジェクト）とそのファイルデータにアクセスしています。
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 最初のシェイプを OLE オブジェクトフレームとして取得します。
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // 埋め込みファイルデータを取得します。
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // 埋め込みファイルの拡張子を取得します。
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```


### **リンクされた OLE オブジェクト フレーム プロパティへのアクセス**

Aspose.Slides を使用すると、リンクされた OLE オブジェクト フレームのプロパティにアクセスできます。

以下の C# コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンクされたファイルへのパスを取得する方法を示します:
```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // 最初のシェイプを OLE オブジェクトフレームとして取得します。
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // OLE オブジェクトがリンクされているか確認します。
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // リンクされたファイルのフルパスを出力します。
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // 存在する場合はリンクされたファイルの相対パスを出力します。
        // 相対パスを含められるのは PPT プレゼンテーションのみです。
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```


## **OLE オブジェクト データの変更**

{{% alert color="primary" %}} 

このセクションのコード例は [Aspose.Cells for .NET](/cells/net/) を使用しています。

{{% /alert %}}

スライドに埋め込まれた OLE オブジェクトが既にある場合、以下の手順でオブジェクトにアクセスしデータを変更できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションを読み込みます。
2. インデックスを使用してスライドの参照を取得します。
3. [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) シェイプにアクセスします。例では、最初のスライドに 1 つだけシェイプがある PPTX を使用し、そのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) として *キャスト* しています。これが目的の OLE オブジェクト フレームです。
4. OLE オブジェクト フレームにアクセスできたら、任意の操作を実行できます。
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。
6. 対象の `Worksheet` にアクセスし、データを修正します。
7. 更新した `Workbook` をストリームに保存します。
8. ストリームから OLE オブジェクト データを置き換えます。

以下の例では、スライドに埋め込まれた OLE オブジェクト フレーム（Excel チャートオブジェクト）にアクセスし、ファイルデータを変更してチャートデータを更新しています。
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 最初のシェイプを OLE オブジェクトフレームとして取得します。
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

Excel チャート以外にも、Aspose.Slides for .NET を使用すると、HTML、PDF、ZIP などのさまざまなファイルをオブジェクトとしてスライドに埋め込めます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連プログラムで自動的に開くか、適切なプログラムを選択するよう促されます。

以下の C# コードは、HTML と ZIP をスライドに埋め込む方法を示します:
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

プレゼンテーションで作業する際、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされたものに置き換える必要があることがあります。Aspose.Slides for .NET を使用すると、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレームのデータや拡張子を更新できます。

以下の C# コードは、埋め込み OLE オブジェクトのファイルタイプを `zip` に設定する方法を示します:
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

OLE オブジェクトを埋め込むと、アイコン画像で構成されたプレビューが自動的に追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビュー要素として使用したい場合は、Aspose.Slides for .NET でアイコン画像とタイトルを設定できます。

以下の C# コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示します:
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


## **OLE オブジェクト フレームのサイズ変更と再配置の防止**

リンクされた OLE オブジェクトをプレゼンテーション スライドに追加した後、PowerPoint でプレゼンテーションを開くと「リンクの更新」メッセージが表示されることがあります。「リンクの更新」ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトのデータを取得してプレビューを更新するため、OLE オブジェクト フレームのサイズや位置が変更されることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) インターフェイスの `UpdateAutomatic` プロパティを `false` に設定します:
```cs
oleFrame.UpdateAutomatic = false;
```


## **埋め込みファイルの抽出**

Aspose.Slides for .NET を使用すると、スライドに OLE オブジェクトとして埋め込まれたファイルを次の手順で抽出できます。
1. 抽出対象の OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのシェイプをループし、[OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) シェイプにアクセスします。
3. OLE オブジェクト フレームから埋め込まれたファイルのデータにアクセスし、ディスクに書き出します。

以下の C# コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示します:
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

**OLE コンテンツは PDF/画像へのエクスポート時にレンダリングされますか？**

スライド上に表示されているものがレンダリングされます――アイコン／代替画像（プレビュー）です。「ライブ」な OLE コンテンツはレンダリング時に実行されません。必要に応じて、エクスポートされた PDF で期待通りに見えるようにプレビュー画像を設定してください。

**スライド上の OLE オブジェクトをロックして、ユーザーが PowerPoint で移動／編集できないようにするには？**

シェイプをロックします。Aspose.Slides は [シェイプレベルのロック](/slides/ja/net/applying-protection-to-presentation/) を提供しています。これは暗号化ではありませんが、誤操作や移動を実質的に防止します。

**リンクされた Excel オブジェクトが「ジャンプ」したりサイズが変わったりするのはなぜですか？**

PowerPoint がリンクされた OLE のプレビューを更新することがあります。安定した表示を得るには、[Worksheet Resizing の実装例](/slides/ja/net/working-solution-for-worksheet-resizing/) に従い、フレームを範囲に合わせるか、範囲を固定フレームに合わせて適切な代替画像を設定してください。

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**

PPTX では「相対パス」情報は利用できず、フルパスのみが保存されます。相対パスは旧形式の PPT にのみ存在します。可搬性を確保するには、信頼できる絶対パス／アクセス可能な URI を使用するか、埋め込みを推奨します。