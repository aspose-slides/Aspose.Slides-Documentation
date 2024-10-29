---  
title: OLEの管理  
type: docs  
weight: 40  
url: /ja/net/manage-ole/  
keywords:  
- OLEの追加  
- OLEの埋め込み  
- オブジェクトの追加  
- オブジェクトの埋め込み  
- ファイルの埋め込み  
- リンクされたオブジェクト  
- オブジェクトのリンクと埋め込み  
- OLEオブジェクト  
- PowerPoint  
- プレゼンテーション  
- C#  
- Csharp  
- Aspose.Slides for .NET  
description: C#または.NETでPowerPointプレゼンテーションにOLEオブジェクトを追加する   
---  

{{% alert title="情報" color="info" %}}  

OLE（オブジェクトリンクと埋め込み）は、Microsoftの技術で、1つのアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みを通じて別のアプリケーションに配置することを可能にします。  

{{% /alert %}}  

MS Excelで作成されたチャートを考えてみましょう。そのチャートは、PowerPointのスライドの中に置かれます。そのExcelのチャートはOLEオブジェクトと見なされます。  

- OLEオブジェクトはアイコンとして表示される場合があります。この場合、アイコンをダブルクリックすると、チャートが関連付けられたアプリケーション（Excel）で開かれるか、オブジェクトの開くまたは編集のためのアプリケーションを選択するように求められます。  
- OLEオブジェクトは実際の内容を表示する場合があります。たとえば、チャートの内容が表示されます。この場合、チャートはPowerPointでアクティブ化され、チャートインターフェースが読み込まれ、PowerPointアプリ内でチャートのデータを修正できます。  

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/)を使用すると、OLEオブジェクトをOLEオブジェクトフレーム（[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)）としてスライドに挿入できます。  

## **スライドにOLEオブジェクトフレームを追加する**  
Microsoft Excelで作成したチャートをOLEオブジェクトフレームとしてAspose.Slides for .NETを使ってスライドに埋め込むことを想定します。このように行うことができます：  

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使ってスライドの参照を取得します。  
3. Excelチャートオブジェクトを含むExcelファイルを開き、`MemoryStream`に保存します。  
4. OLEオブジェクトに関するバイトの配列とその他の情報を含むスライドに[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)を追加します。  
5. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。  

以下の例では、Aspose.Slides for .NETを使用してExcelファイルからスライドに[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)としてチャートを追加しました。  
**注意**：[IOleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo)コンストラクタは、埋め込み可能なオブジェクトの拡張子を2番目のパラメーターとして受け取ります。この拡張子により、PowerPointはファイルタイプを正しく解釈し、このOLEオブジェクトを開くために適切なアプリケーションを選択できます。  

``` csharp  
// PPTXファイルを表すPresentationクラスをインスタンス化  
using (Presentation pres = new Presentation())  
{  
    // 最初のスライドにアクセス  
    ISlide sld = pres.Slides[0];  

    // Excelファイルをストリームに読み込む  
    MemoryStream mstream = new MemoryStream();  
    using (FileStream fs = new FileStream("book1.xlsx", FileMode.Open, FileAccess.Read))  
    {  
        byte[] buf = new byte[4096];  

        while (true)  
        {  
            int bytesRead = fs.Read(buf, 0, buf.Length);  
            if (bytesRead <= 0)  
                break;  
            mstream.Write(buf, 0, bytesRead);  
        }  
    }  

    // 埋め込み用のデータオブジェクトを作成  
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.ToArray(), "xlsx");  

    // Ole Object Frame形状を追加  
    IOleObjectFrame oleObjectFrame = sld.Shapes.AddOleObjectFrame(0, 0, pres.SlideSize.Size.Width,  
        pres.SlideSize.Size.Height, dataInfo);  

    // PPTXファイルを書き込む  
    pres.Save("OleEmbed_out.pptx", SaveFormat.Pptx);  
}  
```  
### リンクされたOLEオブジェクトフレームの追加  

Aspose.Slides for .NETでは、データを埋め込まずにファイルへのリンクのみで[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)を追加できます。  

このC#コードは、スライドにリンクされたExcelファイルを持つ[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)を追加する方法を示しています：  

``` csharp  
using (Presentation pres = new Presentation())  
{  
    // 最初のスライドにアクセス  
    ISlide slide = pres.Slides[0];  

    // リンクされたExcelファイルを持つOle Object Frameを追加  
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book1.xlsx");  

    // PPTXファイルを書き込む  
    pres.Save("OleLinked_out.pptx", SaveFormat.Pptx);  
}  
```  

## **OLEオブジェクトフレームへのアクセス**  
スライドにOLEオブジェクトがすでに埋め込まれている場合、そのオブジェクトを簡単に見つけたりアクセスしたりできます。  

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使ってスライドの参照を取得します。  
3. [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)形状にアクセスします。  
   この例では、最初のスライドに1つの形状を持つ以前に作成されたPPTXを使用しました。そして、*キャスト*して[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)としてそのオブジェクトを使用しました。これがアクセスすべきOLEオブジェクトフレームです。  
4. OLEオブジェクトフレームにアクセスすると、任意の操作を行うことができます。  
以下の例では、OLEオブジェクトフレーム（スライドに埋め込まれたExcelチャートオブジェクト）にアクセスし、そのファイルデータをExcelファイルに書き込みます：  
``` csharp  
// PPTXをプレゼンテーションオブジェクトに読み込む  
using (Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx"))  
{  
    // 最初のスライドにアクセス  
    ISlide sld = pres.Slides[0];  

    // OleObjectFrameに形状をキャスト  
    OleObjectFrame oleObjectFrame = sld.Shapes[0] as OleObjectFrame;  

    // OLEオブジェクトを読み込み、ディスクに書き込む  
    if (oleObjectFrame != null)  
    {  
        // 埋め込まれたファイルデータを取得  
        byte[] data = oleObjectFrame.EmbeddedData.EmbeddedFileData;  

        // 埋め込まれたファイルの拡張子を取得  
        string fileExtention = oleObjectFrame.EmbeddedData.EmbeddedFileExtension;  

        // 抽出したファイルを保存するパスを作成  
        string extractedPath = "excelFromOLE_out" + fileExtention;  

        // 抽出したデータを保存  
        using (FileStream fstr = new FileStream(extractedPath, FileMode.Create, FileAccess.Write))  
        {  
            fstr.Write(data, 0, data.Length);  
        }  
    }  
}  
```  

### リンクされたOLEオブジェクトフレームのプロパティにアクセスする  

Aspose.Slidesでは、リンクされたOLEオブジェクトフレームのプロパティにアクセスできます。  

このC#コードは、OLEオブジェクトがリンクされているかどうかを確認し、リンクされたファイルへのパスを取得する方法を示しています：  
```csharp  
using (Presentation pres = new Presentation("OleLinked.ppt"))  
{  
    // 最初のスライドにアクセス  
    ISlide slide = pres.Slides[0];  

    // 最初の形状をOLEオブジェクトフレームとして取得  
    OleObjectFrame oleObjectFrame = slide.Shapes[0] as OleObjectFrame;  

    // Oleオブジェクトがリンクされているか確認。  
    if (oleObjectFrame != null && oleObjectFrame.IsObjectLink)  
    {  
        // リンクされたファイルへのフルパスを出力  
        Console.WriteLine("Oleオブジェクトフレームは次にリンクされています：" + oleObjectFrame.LinkPathLong);  

        // 存在する場合は、リンクされたファイルへの相対パスを出力。  
        // 相対パスを含むことができるのはPPTプレゼンテーションのみ。  
        string relativePath = oleObjectFrame.LinkPathRelative;  
        if (!string.IsNullOrEmpty(relativePath))  
        {  
            Console.WriteLine("Oleオブジェクトフレームの相対パス：" + oleObjectFrame.LinkPathRelative);  
        }  
    }  
}  
```  
## **OLEオブジェクトデータの変更**  

スライドにOLEオブジェクトがすでに埋め込まれている場合、そのオブジェクトに簡単にアクセスしてデータを修正できます。  

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成して、埋め込まれたOLEオブジェクトを含むプレゼンテーションを開きます。  
2. インデックスを使ってスライドの参照を取得します。  
3. [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)形状にアクセスします。  
   この例では、最初のスライドに1つの形状を持つ以前に作成されたPPTXを使用しました。そして、*キャスト*して[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)としてそのオブジェクトを使用しました。これがアクセスすべきOLEオブジェクトフレームです。  
4. OLEオブジェクトフレームにアクセスすると、任意の操作を行うことができます。  
5. Workbookオブジェクトを作成し、OLEデータにアクセスします。  
6. 希望のワークシートにアクセスし、データを修正します。  
7. 更新されたWorkbookをストリームに保存します。  
8. ストリームデータからOLEオブジェクトデータを変更します。  
以下の例では、OLEオブジェクトフレーム（スライドに埋め込まれたExcelチャートオブジェクト）にアクセスし、チャートデータを変更するためにファイルデータを修正します：  
``` csharp  
using (Presentation pres = new Presentation("ChangeOLEObjectData.pptx"))  
{  
    ISlide slide = pres.Slides[0];  

    OleObjectFrame ole = null;  

    // Oleフレームのためにすべての形状を走査  
    foreach (IShape shape in slide.Shapes)  
    {  
        if (shape is OleObjectFrame)  
        {  
            ole = (OleObjectFrame)shape;  
        }  
    }  

    if (ole != null)  
    {  
        using (MemoryStream msln = new MemoryStream(ole.EmbeddedData.EmbeddedFileData))  
        {  
            // Workbook内のオブジェクトデータを読み込む  
            Workbook Wb = new Workbook(msln);  

            using (MemoryStream msout = new MemoryStream())  
            {  
                // ワークブックデータを修正  
                Wb.Worksheets[0].Cells[0, 4].PutValue("E");  
                Wb.Worksheets[0].Cells[1, 4].PutValue(12);  
                Wb.Worksheets[0].Cells[2, 4].PutValue(14);  
                Wb.Worksheets[0].Cells[3, 4].PutValue(15);  

                OoxmlSaveOptions so1 = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);  
                Wb.Save(msout, so1);  

                // Oleフレームオブジェクトデータを変更  
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(msout.ToArray(), ole.EmbeddedData.EmbeddedFileExtension);  
                ole.SetEmbeddedData(newData);  
            }  
        }  
    }  

    pres.Save("OleEdit_out.pptx", SaveFormat.Pptx);  
}  
```  
## **スライドに他のファイルタイプを埋め込む**  

Excelチャートに加えて、Aspose.Slides for .NETでは他の種類のファイルをスライドに埋め込むこともできます。たとえば、HTML、PDF、およびZIPファイルをオブジェクトとしてスライドに挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、そのオブジェクトは自動的に関連するプログラムで起動されるか、ユーザーがオブジェクトを開くための適切なプログラムを選択するように指示されます。  

このC#コードは、スライドにHTMLとZIPを埋め込む方法を示しています：  
```c#  
using (Presentation pres = new Presentation())  
{  
  ISlide slide = pres.Slides[0];  

  byte[] htmlBytes = File.ReadAllBytes("embedOle.html");  
  IOleEmbeddedDataInfo dataInfoHtml = new OleEmbeddedDataInfo(htmlBytes, "html");  
  IOleObjectFrame oleFrameHtml = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, dataInfoHtml);  
  oleFrameHtml.IsObjectIcon = true;  

  byte[] zipBytes = File.ReadAllBytes("embedOle.zip");  
  IOleEmbeddedDataInfo dataInfoZip = new OleEmbeddedDataInfo(zipBytes, "zip");  
  IOleObjectFrame oleFrameZip = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, dataInfoZip);  
  oleFrameZip.IsObjectIcon = true;  

  pres.Save("embeddedOle.pptx", SaveFormat.Pptx);  
}  
```  
## **埋め込まれたオブジェクトのファイルタイプを設定する**  

プレゼンテーションに取り組んでいるときに、古いOLEオブジェクトを新しいものに置き換える必要があるかもしれません。あるいは、サポートされていないOLEオブジェクトをサポートされているものに置き換える必要があるかもしれません。  

Aspose.Slides for .NETでは、埋め込まれたオブジェクトのファイルタイプを設定できます。このようにして、OLEフレームデータまたはその拡張子を変更できます。  

このC#コードは、埋め込まれたOLEオブジェクトのファイルタイプを設定する方法を示しています：  
```c#  
using (Presentation pres = new Presentation("embeddedOle.pptx"))  
{  
    ISlide slide = pres.Slides[0];  
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];  
    Console.WriteLine($"現在の埋め込まれたデータ拡張子は：{oleObjectFrame.EmbeddedData.EmbeddedFileExtension}");  

    oleObjectFrame.SetEmbeddedData(new OleEmbeddedDataInfo(File.ReadAllBytes("embedOle.zip"), "zip"));  

    pres.Save("embeddedChanged.pptx", SaveFormat.Pptx);  
}  
```  
## **埋め込まれたオブジェクトのアイコン画像とタイトルを設定する**  

OLEオブジェクトを埋め込むと、アイコン画像とタイトルから成るプレビューが自動的に追加されます。このプレビューは、ユーザーがOLEオブジェクトにアクセスまたはオープンする前に見るものです。  

特定の画像とテキストをプレビューの要素として使用したい場合、Aspose.Slides for .NETを使用してアイコン画像とタイトルを設定できます。  

このC#コードは、埋め込まれたオブジェクトのアイコン画像とタイトルを設定する方法を示しています：  
```c#  
using (Presentation pres = new Presentation("embeddedOle.pptx"))  
{  
    ISlide slide = pres.Slides[0];  
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];  

    IPPImage oleImage = pres.Images.AddImage(File.ReadAllBytes("image.png"));  
    oleObjectFrame.SubstitutePictureTitle = "私のタイトル";  
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = oleImage;  
    oleObjectFrame.IsObjectIcon = false;  

    pres.Save("embeddedOle-newImage.pptx", SaveFormat.Pptx);  
}  
```  

## **OLEオブジェクトフレームがリサイズおよび再配置されるのを防ぐ**  

プレゼンテーションスライドにリンクされたOLEオブジェクトを追加した後、PowerPointでプレゼンテーションを開くと、リンクを更新するように求められるメッセージが表示される場合があります。「リンクを更新」ボタンをクリックすると、OLEオブジェクトフレームのサイズや位置が変更されることがあります。これは、PowerPointがリンクされたOLEオブジェクトからデータを更新し、オブジェクトプレビューをリフレッシュするからです。PowerPointがオブジェクトのデータを更新するように促すのを防ぐには、[IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/)インターフェースの`UpdateAutomatic`プロパティを`false`に設定します：  

```cs  
oleObjectFrame.UpdateAutomatic = false;  
```  

## **埋め込まれたファイルの抽出**  

Aspose.Slides for .NETを使用すると、OLEオブジェクトとしてスライドに埋め込まれたファイルを次のように抽出できます：  
1. 抽出したいOLEオブジェクトを含む[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。  
2. プレゼンテーション内のすべての形状をループし、[OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)形状にアクセスします。  
3. OLEオブジェクトフレームから埋め込まれたファイルのデータにアクセスし、ディスクに書き込みます。  
このC#コードは、スライドに埋め込まれたファイルをOLEオブジェクトとして抽出する方法を示しています：  
```c#  
using (Presentation pres = new Presentation("embeddedOle.pptx"))  
{  
    ISlide slide = pres.Slides[0];  

    for (var index = 0; index < slide.Shapes.Count; index++)  
    {  
        IShape shape = slide.Shapes[index];  
        
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;  
        
        if (oleFrame != null)  
        {  
            byte[] data = oleFrame.EmbeddedData.EmbeddedFileData;  
            string extension = oleFrame.EmbeddedData.EmbeddedFileExtension;  
            
            File.WriteAllBytes($"oleFrame{index}{extension}", data);  
        }  
    }  
}  
```  