---
title: OLEの管理
type: docs
weight: 40
url: /ja/cpp/manage-ole/
keywords:
- OLEの追加
- OLEの埋め込み
- オブジェクトの追加
- オブジェクトの埋め込み
- ファイルの埋め込み
- リンクされたオブジェクト
- オブジェクトリンク＆埋め込み
- OLEオブジェクト
- PowerPoint 
- プレゼンテーション
- C++
- Aspose.Slides for C++
description: C++でPowerPointプレゼンテーションにOLEオブジェクトを追加します。
---

{{% alert title="情報" color="info" %}}

OLE（オブジェクトリンク＆埋め込み）は、Microsoftの技術で、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みを通じて別のアプリケーションに配置することを可能にします。 

{{% /alert %}} 

MS Excelで作成されたチャートを考えてみてください。そのチャートはPowerPointスライドに配置されます。そのExcelチャートはOLEオブジェクトと見なされます。 

- OLEオブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、チャートが関連付けられたアプリケーション（Excel）で開かれるか、オブジェクトを開くまたは編集するためのアプリケーションを選択するよう求められます。 
- OLEオブジェクトは実際のコンテンツを表示することがあります。たとえば、チャートの内容。 この場合、PowerPointでチャートがアクティブになり、チャートインターフェースが読み込まれ、PowerPointアプリ内でチャートのデータを変更できます。

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/)を使用すると、OLEオブジェクトをOLEオブジェクトフレームとしてスライドに挿入できます（[OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)）。

## **スライドへのOLEオブジェクトフレームの追加**

Microsoft Excelでチャートをすでに作成し、そのチャートをAspose.Slides for C++を使用してOLEオブジェクトフレームとしてスライドに埋め込みたい場合は、次のように行います：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. Excelチャートオブジェクトを含むExcelファイルを開き、`MemoryStream`に保存します。
4. OLEオブジェクトに関するバイト配列とその他の情報を含むスライドに[OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)を追加します。
5. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、ExcelファイルからのチャートをAspose.Slides for C++を使用してスライドに[OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)として追加しました。  
**注意**： [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_ole_embedded_data_info)コンストラクタは、2番目のパラメータとして埋め込み可能なオブジェクトの拡張子を取ります。この拡張子により、PowerPointはファイルタイプを正しく解釈し、このOLEオブジェクトを開くのに適切なアプリケーションを選択します。

``` cpp
// ドキュメントディレクトリへのパス。
String dataDir = u"";
// PPTXを表すPresentationクラスをインスタンス化
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);
// ストリームにExcelファイルをロード
SharedPtr<MemoryStream> mstream = System::MakeObject<MemoryStream>();

SharedPtr<FileStream> fs = System::MakeObject<FileStream>(dataDir + u"book1.xlsx", FileMode::Open, FileAccess::Read);

ArrayPtr<uint8_t> buf = System::MakeArray<uint8_t>(4096, 0);
while (true)
{
    int32_t bytesRead = fs->Read(buf, 0, buf->get_Length());
    if (bytesRead <= 0)
    {
        break;
    }
    mstream->Write(buf, 0, bytesRead);
}

// 埋め込み用のデータオブジェクトを作成
SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(mstream->ToArray(), u"xlsx");
// Ole Object Frame形状を追加
SharedPtr<IOleObjectFrame> oleObjectFrame = sld->get_Shapes()->AddOleObjectFrame(0.0f, 0.0f, pres->get_SlideSize()->get_Size().get_Width(), pres->get_SlideSize()->get_Size().get_Height(), dataInfo);
// PPTXファイルをディスクに書き込み
pres->Save(dataDir + u"OleEmbed_out.pptx", SaveFormat::Pptx);
```

## **OLEオブジェクトフレームへのアクセス**
OLEオブジェクトがすでにスライドに埋め込まれている場合、そのオブジェクトを簡単に見つけたりアクセスしたりできます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。

2. インデックスを使用してスライドの参照を取得します。

3. [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)形状にアクセスします。

   私たちの例では、最初のスライドに1つの形状のみがある既に作成されたPPTXを使用しました。次に、そのオブジェクトを[OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)として*キャスト*しました。これがアクセスする必要があるOLEオブジェクトフレームです。

4. OLEオブジェクトフレームにアクセスしたら、任意の操作を実行できます。

以下の例では、OLEオブジェクトフレーム（スライドに埋め込まれたExcelチャートオブジェクト）にアクセスし、そのファイルデータをExcelファイルに書き込みます：

``` cpp
// ドキュメントディレクトリへのパス。
const String templatePath = u"../templates/AccessingOLEObjectFrame.pptx";

// 希望のプレゼンテーションをロード
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// 最初のスライドにアクセス
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 形状をOleObjectFrameにキャスト
SharedPtr<OleObjectFrame> oleObjectFrame = System::AsCast<OleObjectFrame>(sld->get_Shapes()->idx_get(0));

// OLEオブジェクトを読み込み、ディスクに書き込む
if (oleObjectFrame != nullptr)
{
    // 埋め込まれたファイルデータを取得
    ArrayPtr<uint8_t> data = oleObjectFrame->get_EmbeddedFileData();

    // 埋め込まれたファイル拡張子を取得
    String fileExtention = oleObjectFrame->get_EmbeddedFileExtension();

    // 抽出されたファイルを保存するパスを作成
    String extractedPath = Path::Combine(GetOutPath(), u"excelFromOLE_out" + fileExtention);

    // 抽出データを保存
    SharedPtr<FileStream> fstr = System::MakeObject<FileStream>(extractedPath, FileMode::Create, FileAccess::Write);
    fstr->Write(data, 0, data->get_Length());
}
```

## **OLEオブジェクトデータの変更**
OLEオブジェクトがすでにスライドに埋め込まれている場合、そのオブジェクトに簡単にアクセスし、そのデータを変更できます：

1. 埋め込まれたOLEオブジェクトを持つ希望のプレゼンテーションを[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成して開きます。

2. インデックスを使用してスライドの参照を取得します。 

3. [OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)形状にアクセスします。

   私たちの例では、最初のスライドに1つの形状がある既存のPPTXを使用しました。そしてそのオブジェクトを[OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)として*キャスト*しました。これがアクセスする必要があるOLEオブジェクトフレームです。

4. OLEオブジェクトフレームにアクセスしたら、任意の操作を実行できます。

5. Workbookオブジェクトを作成し、OLEデータにアクセスします。

6. 希望のワークシートにアクセスしてデータを修正します。

7. 更新されたWorkbookをストリームに保存します。

8. OLEオブジェクトのデータをストリームデータから変更します。

以下の例ではOLEオブジェクトフレーム（スライドに埋め込まれたExcelチャートオブジェクト）にアクセスし、そのファイルデータを変更してチャートデータを変更します：

``` cpp
intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> ToCellsMemoryStream(System::ArrayPtr<uint8_t> buffer)
{
    intrusive_ptr<BString> array = new BString(buffer->data_ptr(), buffer->Count());
    auto stream = new Aspose::Cells::Systems::IO::MemoryStream(array);

    return stream;
}

System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}

void ChangeOLEObjectData()
{
    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(GetDataPath() + u"ChangeOLEObjectData.pptx");
    System::SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

    System::SharedPtr<OleObjectFrame> ole;

    // Oleフレームのためにすべての形状をトラバース
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        if (System::ObjectExt::Is<OleObjectFrame>(shape))
        {
            ole = System::ExplicitCast<OleObjectFrame>(shape);
        }
    }
    
    if (ole != nullptr)
    {
        // Workbook内のオブジェクトデータを読み取る
        intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> cellsInputStream = ToCellsMemoryStream(ole->get_ObjectData());
        intrusive_ptr<Aspose::Cells::IWorkbook> Wb = Aspose::Cells::Factory::CreateIWorkbook(cellsInputStream);

        // ワークブックデータを修正
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(0,4)->PutValue(u"E");
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(1, 4)->PutValue(12);
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(2, 4)->PutValue(14);
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(3, 4)->PutValue(15);

        intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
        Wb->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);
        
        // Oleフレームオブジェクトデータを変更
        cellsOutputStream->SetPosition(0);
        System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);
        ole->set_ObjectData(msout->ToArray());
        
        pres->Save(GetOutPath() + u"OleEdit_out.pptx", Export::SaveFormat::Pptx);
    }
}
```

## スライドへの他のファイルタイプの埋め込み

Excelチャートのほかに、Aspose.Slides for C++を使用すると、スライドに他のファイルタイプを埋め込むことができます。たとえば、HTML、PDF、およびZIPファイルをスライドにオブジェクトとして挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、オブジェクトは自動的に関連プログラムで起動されるか、ユーザーが適切なプログラムを選択するように指示されます。 

このC++コードは、スライドにHTMLとZIPを埋め込む方法を示しています：

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto htmlBytes = System::IO::File::ReadAllBytes(u"embedOle.html");

auto dataInfoHtml = System::MakeObject<OleEmbeddedDataInfo>(htmlBytes, u"html");
auto oleFrameHtml = slide->get_Shapes()->AddOleObjectFrame(150.0f, 120.0f, 50.0f, 50.0f, dataInfoHtml);
oleFrameHtml->set_IsObjectIcon(true);
        
auto zipBytes = System::IO::File::ReadAllBytes(u"embedOle.zip");
auto dataInfoZip = System::MakeObject<OleEmbeddedDataInfo>(zipBytes, u"zip");
auto oleFrameZip = slide->get_Shapes()->AddOleObjectFrame(150.0f, 220.0f, 50.0f, 50.0f, dataInfoZip);
oleFrameZip->set_IsObjectIcon(true);
        
pres->Save(u"embeddedOle.pptx", SaveFormat::Pptx);

```

## 埋め込まれたオブジェクトのファイルタイプの設定

プレゼンテーションを作成する際、古いOLEオブジェクトを新しいものに置き換える必要がある場合や、サポートされていないOLEオブジェクトをサポートされているものに置き換える必要がある場合があります。

Aspose.Slides for C++を使用すると、埋め込まれたオブジェクトのファイルタイプを設定できます。この方法により、OLEフレームデータを変更したり、拡張子を変更したりできます。

このC++コードは、埋め込まれたOLEオブジェクトのファイルタイプを設定する方法を示しています：

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slides()->idx_get(0);
auto oleObjectFrame = System::ExplicitCast<IOleObjectFrame>(slide->get_Shapes()->idx_get(0));
Console::WriteLine(u"現在の埋め込まれたデータ拡張子: {0}", oleObjectFrame->get_EmbeddedData()->get_EmbeddedFileExtension());

oleObjectFrame->SetEmbeddedData(System::MakeObject<OleEmbeddedDataInfo>(File::ReadAllBytes(u"embedOle.zip"), u"zip"));

pres->Save(u"embeddedChanged.pptx", SaveFormat::Pptx);
```

## 埋め込まれたオブジェクトのアイコン画像およびタイトルの設定

OLEオブジェクトを埋め込むと、自動的にアイコン画像とタイトルからなるプレビューが追加されます。このプレビューは、ユーザーがOLEオブジェクトにアクセスまたは開く前に見えるものです。

特定の画像およびテキストをプレビューの要素として使用する場合、Aspose.Slides for C++を使用してアイコン画像とタイトルを設定できます。

このC++コードは、埋め込まれたオブジェクトのアイコン画像とタイトルを設定する方法を示しています：

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slide(0);
auto oleObjectFrame = System::ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto oleImage = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
oleObjectFrame->set_SubstitutePictureTitle(u"私のタイトル");
oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleObjectFrame->set_IsObjectIcon(false);

pres->Save(u"embeddedOle-newImage.pptx", SaveFormat::Pptx);
```

## **OLEオブジェクトフレームのリサイズと再配置を防止する**

リンクされたOLEオブジェクトをプレゼンテーションスライドに追加した後、PowerPointでプレゼンテーションを開くと、リンクを更新するよう求めるメッセージが表示されることがあります。「リンクを更新」ボタンをクリックすると、OLEオブジェクトフレームのサイズと位置が変更される場合があります。これは、PowerPointがリンクされたOLEオブジェクトからデータを更新し、オブジェクトのプレビューを更新するためです。PowerPointがオブジェクトのデータを更新するように求めるのを防ぐために、[IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/)インターフェースの`set_UpdateAutomatic`メソッドを`false`に設定します：

```cpp
oleObjectFrame->set_UpdateAutomatic(false);
```

## 埋め込まれたファイルの抽出

Aspose.Slides for C++を使用すると、OLEオブジェクトとしてスライドに埋め込まれたファイルを次のように抽出できます：

1. 抽出したいOLEオブジェクトを含む[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. プレゼンテーション内のすべての形状をループし、[OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)形状にアクセスします。
3. OLEオブジェクトフレームから埋め込まれたファイルのデータにアクセスし、それをディスクに書き込みます。

このC++コードは、OLEオブジェクトとしてスライドに埋め込まれたファイルを抽出する方法を示しています：

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slides()->idx_get(0);

for (int32_t index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shapes()->idx_get(index);

    auto oleFrame = System::AsCast<IOleObjectFrame>(shape);

    if (oleFrame != nullptr)
    {
        auto data = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        String extension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        File::WriteAllBytes(String::Format(u"oleFrame{0}{1}", index, extension), data);
    }
}
```