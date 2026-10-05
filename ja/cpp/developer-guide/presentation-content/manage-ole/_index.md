---
title: C++ を使用したプレゼンテーションでの OLE 管理
linktitle: OLE の管理
type: docs
weight: 40
url: /ja/cpp/manage-ole/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument ファイルの OLE オブジェクト管理を最適化します。OLE コンテンツの埋め込み、更新、エクスポートをシームレスに行えます。"
---
## **はじめに**

{{% alert color="info" title="Note" %}}
OLE（Object Linking & Embedding）は、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みによって別のアプリケーションに配置できる Microsoft の技術です。
{{% /alert %}}

MS Excel で作成されたチャートを考えてみてください。そのチャートが PowerPoint のスライドに配置されます。この Excel のチャートは OLE オブジェクトと見なされます。

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、チャートが関連付けられたアプリケーション（Excel）で開かれるか、オブジェクトの開封または編集のためにアプリケーションを選択するよう求められます。  
- OLE オブジェクトは実際の内容（例えばチャートの内容）を表示することがあります。この場合、PowerPoint 内でチャートがアクティブになり、チャートインターフェイスが読み込まれ、PowerPoint 内でチャートのデータを変更できます。

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) は、スライドに OLE オブジェクトを OLE オブジェクト フレーム（[OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)）として挿入できます。

## **スライドに OLE オブジェクト フレームを追加する**

Microsoft Excel で既にチャートを作成し、Aspose.Slides for C++ を使用して OLE オブジェクト フレームとしてスライドに埋め込む場合、以下の手順で実行できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. Excel ファイルをバイト配列として読み取ります。  
4. バイト配列および OLE オブジェクトに関するその他の情報を含む [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) をスライドに追加します。  
5. 変更したプレゼンテーションを書き出して PPTX ファイルにします。

以下の例では、Excel ファイルからチャートを取得し、Aspose.Slides for C++ を使用して [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) としてスライドに追加しました。**注意**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) コンストラクタは第2パラメータとして埋め込むオブジェクトの拡張子を受け取ります。この拡張子により PowerPoint はファイルタイプを正しく解釈し、適切なアプリケーションで OLE オブジェクトを開くことができます。

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **リンクされた OLE オブジェクト フレームの追加**

Aspose.Slides for C++ は、データを埋め込まずにファイルへのリンクだけで [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) を追加できます。

この C++ コードは、リンクされた Excel ファイルを使用してスライドに [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) を追加する方法を示しています：

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// リンクされた Excel ファイルを使用して OLE オブジェクト フレームを追加します。
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE オブジェクト フレームへのアクセス**

スライドに OLE オブジェクトが既に埋め込まれている場合、以下の手順で簡単に見つけたりアクセスしたりできます：

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成して、埋め込み OLE オブジェクトを含むプレゼンテーションをロードします。  
2. インデックスを使用してスライドの参照を取得します。  
3. [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) シェイプにアクセスします。例では、先に作成した PPTX（最初のスライドにシェイプが 1 つだけある）を使用しました。そのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) に *cast* しました。これがアクセス対象の OLE オブジェクト フレームです。  
4. OLE オブジェクト フレームにアクセスできたら、任意の操作を実行できます。

以下の例では、OLE オブジェクト フレーム（スライドに埋め込まれた Excel チャート オブジェクト）とそのファイルデータにアクセスしています。

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // 埋め込みファイル データを取得します。
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // 埋め込みファイルの拡張子を取得します。
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **リンクされた OLE オブジェクト フレーム プロパティへのアクセス**

Aspose.Slides は、リンクされた OLE オブジェクト フレームのプロパティにアクセスできます。

この C++ コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンクされたファイルへのパスを取得する方法を示しています：

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // OLE オブジェクトがリンクされているか確認します。
    if (oleFrame->get_IsObjectLink())
    {
        // リンクされたファイルへのフルパスを出力します。
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // 存在する場合はリンクされたファイルへの相対パスを出力します。
        // 相対パスを含められるのは PPT プレゼンテーションだけです。
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **OLE オブジェクト データの変更**

{{% alert color="info" title="Note" %}}
このセクションでは、以下のコード例で [Aspose.Cells for C++](https://docs.aspose.com/cells/cpp/) を使用しています。
{{% /alert %}}

スライドに OLE オブジェクトが既に埋め込まれている場合、以下の手順でそのオブジェクトにアクセスし、データを変更できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成して、埋め込み OLE オブジェクトを含むプレゼンテーションをロードします。  
2. インデックスを使用してスライドの参照を取得します。  
3. [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) シェイプにアクセスします。例では、先に作成した PPTX（最初のスライドにシェイプが 1 つある）を使用しました。そのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) に *cast* しました。これがアクセス対象の OLE オブジェクト フレームです。  
4. OLE オブジェクト フレームにアクセスできたら、任意の操作を実行できます。  
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。  
6. 目的の `Worksheet` にアクセスし、データを修正します。  
7. 更新した `Workbook` をストリームに保存します。  
8. ストリームから OLE オブジェクト データを変更します。

以下の例では、OLE オブジェクト フレーム（スライドに埋め込まれた Excel チャート オブジェクト）にアクセスし、ファイルデータを変更してチャート データを更新しています。

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Aspose.Cells for C++ は、その型を使用する前に起動する必要があります。
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// 最初のシェイプを OLE オブジェクト フレームとして取得します。
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // OLE オブジェクト データを Workbook オブジェクトとして読み取ります。
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Workbook データを変更します。
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // OLE フレーム オブジェクト データを変更します。
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **スライドに他のファイルタイプを埋め込む**

Excel チャートに加えて、Aspose.Slides for C++ はスライドに他の種類のファイルを埋め込むことも可能です。たとえば、HTML、PDF、ZIP ファイルをオブジェクトとして挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、自動的に関連プログラムで開くか、適切なプログラムを選択するよう求められます。

この C++ コードは、HTML と ZIP をスライドに埋め込む方法を示しています：

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **埋め込みオブジェクトのファイルタイプを設定する**

プレゼンテーションを扱う際、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされたものに置き換える必要がある場合があります。Aspose.Slides for C++ は、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレームのデータや拡張子を更新できます。

この C++ コードは、埋め込み OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています：

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// ファイルタイプを ZIP に変更します。
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **埋め込みオブジェクトのアイコン画像とタイトルの設定**

OLE オブジェクトを埋め込むと、アイコン画像からなるプレビューが自動的に追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。プレビューに特定の画像とテキストを使用したい場合は、Aspose.Slides for C++ を使用してアイコン画像とタイトルを設定できます。

この C++ コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています：

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to the presentation resources.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE オブジェクト フレームのサイズ変更と再配置を防止する**

リンクされた OLE オブジェクトをプレゼンテーション スライドに追加した後、PowerPoint でプレゼンテーションを開くと、リンクの更新を求めるメッセージが表示されることがあります。\"Update Links\" ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトからデータを更新しオブジェクトのプレビューを再描画するため、OLE オブジェクト フレームのサイズと位置が変更されることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[set_UpdateAutomatic](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/set_updateautomatic/) メソッドを `false` として [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) インターフェイスで呼び出します：

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **埋め込みファイルの抽出**

Aspose.Slides for C++ は、埋め込みファイルを OLE オブジェクトとしてスライドから抽出する方法を提供します：

1. 抽出したい OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. プレゼンテーション内のすべてのシェイプをループし、[OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) シェイプにアクセスします。  
3. OLE オブジェクト フレームから埋め込みファイルのデータにアクセスし、ディスクに書き出します。

この C++ コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています：

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **よくある質問**

**スライドを PDF/画像にエクスポートする際に OLE コンテンツはレンダリングされますか？**

スライド上に表示されているもの、すなわちアイコン/代替画像（プレビュー）がレンダリングされます。実際の「ライブ」 OLE コンテンツはレンダリング時に実行されません。必要に応じて、独自のプレビュー画像を設定し、エクスポートされた PDF で期待通りの外観になるようにしてください。

埋め込みファイルを PDF 添付として保持するには、[PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) を `true` で呼び出します。このオプションはデフォルトで無効です。例と添付ファイルの確認手順については、[Preserve Embedded OLE Files as PDF Attachments](/slides/ja/cpp/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) を参照してください。

**PowerPoint でユーザーが OLE オブジェクトを移動/編集できないようにロックするにはどうすればよいですか？**

シェイプをロックします。Aspose.Slides は [shape-level locks](/slides/ja/cpp/applying-protection-to-presentation/) を提供しています。これは暗号化ではありませんが、誤って編集や移動することを効果的に防止します。

**リンクされた Excel オブジェクトがプレゼンテーションを開くと「ジャンプ」したりサイズが変わったりするのはなぜですか？**

PowerPoint はリンクされた OLE のプレビューを更新することがあります。安定した外観にするには、[Working Solution for Worksheet Resizing](/slides/ja/cpp/working-solution-for-worksheet-resizing/) の手順に従ってください。フレームを範囲に合わせるか、範囲を固定フレームにスケーリングし、適切な代替画像を設定します。

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**

PPTX では「相対パス」情報は利用できず、フルパスのみが保存されます。相対パスは旧形式の PPT に存在します。移植性を考慮する場合、信頼できる絶対パス/アクセス可能な URI、または埋め込みを使用することを推奨します。