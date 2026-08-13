---
title: C++ を使用したプレゼンテーションでの OLE 管理
linktitle: OLE の管理
type: docs
weight: 40
url: /ja/cpp/manage-ole/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument ファイルにおける OLE オブジェクトの管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---
## **はじめに**

{{% alert title="Info" color="info" %}}

OLE（Object Linking & Embedding）は、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みにより別のアプリケーションに配置できる Microsoft の技術です。

{{% /alert %}}

MS Excel で作成したグラフを例にします。そのグラフを PowerPoint のスライドに配置すると、Excel のグラフは OLE オブジェクトとして扱われます。

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、関連付けられたアプリケーション（Excel）でグラフが開くか、オブジェクトの開閉や編集に使用するアプリケーションの選択が求められます。
- OLE オブジェクトは実際の内容（例えばグラフの内容）を表示することもあります。この場合、PowerPoint 内でグラフがアクティブになり、インターフェイスが読み込まれ、PowerPoint 上でグラフのデータを変更できます。

[Aspose.Slides for C++](https://products.aspose.com/slides/ja/cpp/) を使用すると、スライドに OLE オブジェクトを OLE オブジェクトフレーム（[OleObjectFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/oleobjectframe/)）として挿入できます。

## **スライドに OLE オブジェクトフレームを追加する**

Microsoft Excel で既にグラフを作成し、Aspose.Slides for C++ を使って OLE オブジェクトフレームとしてスライドに埋め込みたい場合、以下の手順で実行できます。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. Excel ファイルをバイト配列として読み取ります。
4. バイト配列と OLE オブジェクトに関するその他の情報を指定して、スライドに [OleObjectFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/oleobjectframe/) を追加します。
5. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、Excel ファイルからグラフを取得し、Aspose.Slides for C++ を使用して [OleObjectFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/oleobjectframe/) としてスライドに追加しています。
**Note**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) コンストラクタは第二パラメータとして埋め込み可能オブジェクトの拡張子を受け取ります。この拡張子により PowerPoint はファイルタイプを正しく解釈し、適切なアプリケーションで OLE オブジェクトを開くことができます。

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

### **リンクされた OLE オブジェクトフレームを追加する**

Aspose.Slides for C++ を使用すると、データを埋め込まずにファイルへのリンクのみで [OleObjectFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/oleobjectframe/) を追加できます。

以下の C++ コードは、リンクされた Excel ファイルを持つ [OleObjectFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/oleobjectframe/) をスライドに追加する方法を示しています。

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

// リンクされた Excel ファイルで OLE オブジェクトフレームを追加します。
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE オブジェクトフレームにアクセスする**

スライドに既に埋め込まれた OLE オブジェクトがある場合、以下の手順で簡単に取得またはアクセスできます。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションをロードします。
2. インデックスを使用してスライドへの参照を取得します。
3. [OleObjectFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/oleobjectframe/) シェイプにアクセスします。例では、最初のスライドに 1 つのシェイプしかない PPTX を使用し、そのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ioleobjectframe/) として *cast* しています。これが目的の OLE オブジェクトフレームです。
4. OLE オブジェクトフレームにアクセスできたら、任意の操作を実行できます。

以下の例では、OLE オブジェクトフレーム（スライドに埋め込まれた Excel グラフオブジェクト）とそのファイルデータにアクセスしています。

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

    // 埋め込みファイルデータを取得します。
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // 埋め込みファイルの拡張子を取得します。
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **リンクされた OLE オブジェクトフレームのプロパティにアクセスする**

Aspose.Slides を使用すると、リンクされた OLE オブジェクトフレームのプロパティにアクセスできます。

以下の C++ コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンクされたファイルへのパスを取得する方法を示しています。

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

        // 存在する場合、リンクされたファイルへの相対パスを出力します。
        // 相対パスを含められるのは PPT プレゼンテーションのみです。
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **OLE オブジェクトのデータを変更する**

{{% alert color="info" %}} 

このセクションのコード例は [Aspose.Cells for C++](/cells/cpp/) を使用しています。

{{% /alert %}}

スライドに既に埋め込まれた OLE オブジェクトがある場合、以下の手順でオブジェクトにアクセスし、データを変更できます。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションをロードします。
2. インデックスを使用してスライドへの参照を取得します。
3. [OLEObjectFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/oleobjectframe/) シェイプにアクセスします。例では、最初のスライドに 1 つのシェイプがある PPTX を使用し、そのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ioleobjectframe/) として *cast* しています。これが目的の OLE オブジェクトフレームです。
4. OLE オブジェクトフレームにアクセスできたら、任意の操作を実行できます。
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。
6. 対象の `Worksheet` を取得し、データを修正します。
7. 更新した `Workbook` をストリームに保存します。
8. ストリームから OLE オブジェクトのデータを置き換えます。

以下の例では、OLE オブジェクトフレーム（スライドに埋め込まれた Excel グラフオブジェクト）にアクセスし、そのファイルデータを変更してグラフデータを更新しています。

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

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // OLE オブジェクトデータを Workbook オブジェクトとして読み取ります。
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Workbook のデータを修正します。
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

    // OLE フレームオブジェクトのデータを変更します。
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **スライドに他のファイルタイプを埋め込む**

Excel グラフに加えて、Aspose.Slides for C++ は HTML、PDF、ZIP などのさまざまなファイルをスライドに埋め込むことができます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連プログラムで自動的に開くか、適切なプログラムの選択を求められます。

以下の C++ コードは、HTML と ZIP をスライドに埋め込む方法を示しています。

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

プレゼンテーションを扱う際、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされたものに置き換える必要があることがあります。Aspose.Slides for C++ を使用すると、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレームデータや拡張子の更新が可能です。

以下の C++ コードは、埋め込み OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています。

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

## **埋め込みオブジェクトのアイコン画像とタイトルを設定する**

OLE オブジェクトを埋め込むと、プレビューとしてアイコン画像が自動的に追加されます。これはユーザーがオブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビューに使用したい場合、Aspose.Slides for C++ を使ってアイコン画像とタイトルを設定できます。

以下の C++ コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています。

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

// プレゼンテーションのリソースに画像を追加します。
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **OLE オブジェクトフレームのサイズ変更と再配置を防止する**

リンクされた OLE オブジェクトをプレゼンテーションのスライドに追加した後、PowerPoint でプレゼンテーションを開くと「リンクの更新」メッセージが表示されることがあります。「Update Links」ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトからデータを更新し、プレビューを再描画するため、OLE オブジェクトフレームのサイズや位置が変更されることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[IOleObjectFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ioleobjectframe/) インターフェイスの `set_UpdateAutomatic` メソッドを `false` に設定します。

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

## **埋め込みファイルを抽出する**

Aspose.Slides for C++ を使用すると、スライドに埋め込まれた OLE オブジェクトとしてのファイルを次の手順で抽出できます。

1. 抽出対象の OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのシェイプをループし、[OLEObjectFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/oleobjectframe/) シェイプにアクセスします。
3. OLE オブジェクトフレームから埋め込みファイルのデータを取得し、ディスクに書き出します。

以下の C++ コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています。

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

## **FAQ**

### スライドを PDF/画像にエクスポートするとき、OLE コンテンツはレンダリングされますか？

スライド上に表示されているものがレンダリングされます—アイコン/代替画像（プレビュー）です。「ライブ」な OLE コンテンツはレンダリング時に実行されません。必要に応じて、期待通りの外観になるようプレビュー画像を設定してください。

### PowerPoint でユーザーが OLE オブジェクトを移動/編集できないようにロックするには？

シェイプをロックします：Aspose.Slides は [shape-level locks](/slides/ja/cpp/applying-protection-to-presentation/) を提供します。これは暗号化ではありませんが、誤操作や移動を事実上防止します。

### リンクされた Excel オブジェクトを開くと「ジャンプ」したりサイズが変わったりするのはなぜですか？

PowerPoint はリンクされた OLE のプレビューをリフレッシュすることがあります。安定した表示を保つには、[Working Solution for Worksheet Resizing](/slides/ja/cpp/working-solution-for-worksheet-resizing/) の手順に従い、フレームを範囲に合わせるか、範囲を固定フレームにスケールし、適切な代替画像を設定してください。

### PPTX 形式でリンクされた OLE オブジェクトの相対パスは保持されますか？

PPTX では「相対パス」情報は保持されず、完全パスのみが保存されます。相対パスは古い PPT 形式でのみ利用可能です。可搬性を確保するには、確実な絶対パスまたはアクセス可能な URI、または埋め込みを使用してください。