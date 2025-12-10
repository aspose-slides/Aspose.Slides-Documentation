---
title: C++ を使用したプレゼンテーションでの OLE 管理
linktitle: OLE の管理
type: docs
weight: 40
url: /ja/cpp/manage-ole/
keywords:
- OLE オブジェクト
- オブジェクト リンキング & 埋め込み
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument ファイルでの OLE オブジェクト管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---

{{% alert title="Info" color="info" %}}

OLE（Object Linking & Embedding）は、Microsoft の技術で、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みにより別のアプリケーションに配置できるようにします。

{{% /alert %}} 

MS Excel で作成したグラフを考えてみます。そのグラフを PowerPoint のスライドに配置した場合、Excel のグラフは OLE オブジェクトとして扱われます。

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、関連付けられたアプリケーション（Excel）でグラフが開くか、オブジェクトの開閉や編集に使用するアプリケーションの選択を求められます。  
- OLE オブジェクトは実際の内容（たとえばグラフの内容）を表示することもあります。この場合、PowerPoint でグラフがアクティブ化され、インターフェイスが表示され、PowerPoint 内でグラフのデータを編集できます。

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) を使用すると、OLE オブジェクトをスライドに OLE オブジェクトフレーム（[OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)）として挿入できます。

## **スライドに OLE オブジェクトフレームを追加する**

Microsoft Excel で作成したグラフを Aspose.Slides for C++ を使用して OLE オブジェクトフレームとしてスライドに埋め込む手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. Excel ファイルをバイト配列として読み取ります。  
4. バイト配列および OLE オブジェクトに関するその他の情報を含む [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) をスライドに追加します。  
5. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、Excel ファイルからグラフを取得し、[OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) としてスライドに追加しています。  
**Note**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) コンストラクタは、第二引数として埋め込み可能なオブジェクトの拡張子を受け取ります。この拡張子により、PowerPoint はファイルの種類を正しく解釈し、適切なアプリケーションで OLE オブジェクトを開くことができます。
``` cpp
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


### **リンクされた OLE オブジェクトフレームの追加**

Aspose.Slides for C++ では、データを埋め込まずにファイルへのリンクだけで [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) を追加できます。

以下の C++ コードは、リンクされた Excel ファイルを持つ [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) をスライドに追加する方法を示しています:
```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// リンクされた Excel ファイルを使用して OLE オブジェクトフレームを追加します。
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **OLE オブジェクトフレームへのアクセス**

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順で簡単に検索またはアクセスできます。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションを読み込みます。  
2. インデックスを使用して対象スライドへの参照を取得します。  
3. [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) シェイプにアクセスします。  
   本例では、最初のスライドに 1 つだけシェイプがある事前に作成した PPTX を使用し、そのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) に *キャスト* しました。これが目的の OLE オブジェクトフレームです。  
4. OLE オブジェクトフレームにアクセスできたら、任意の操作を実行できます。

以下の例では、スライドに埋め込まれた OLE オブジェクトフレーム（Excel のグラフオブジェクト）とそのファイルデータにアクセスしています。
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // 埋め込まれたファイルデータを取得します。
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // 埋め込まれたファイルの拡張子を取得します。
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```


### **リンクされた OLE オブジェクトフレームのプロパティにアクセスする**

Aspose.Slides では、リンクされた OLE オブジェクトフレームのプロパティにアクセスできます。

以下の C++ コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンクされたファイルへのパスを取得する方法を示しています:
```cpp
auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // OLE オブジェクトがリンクされているかチェックします。
    if (oleFrame->get_IsObjectLink())
    {
        // リンクされたファイルへのフルパスを出力します。
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // 存在する場合、リンクされたファイルへの相対パスを出力します。
        // 相対パスを含められるのは PPT プレゼンテーションだけです。
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```


## **OLE オブジェクトデータの変更**

{{% alert color="primary" %}} 

このセクションでは、以下のコード例で [Aspose.Cells for C++](/cells/cpp/) を使用しています。

{{% /alert %}}

スライドに埋め込まれた OLE オブジェクトが既に存在する場合、次の手順でそのオブジェクトにアクセスし、データを変更できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションを読み込みます。  
2. インデックスを使用してスライドへの参照を取得します。  
3. [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) シェイプにアクセスします。  
   本例では、最初のスライドに 1 つのシェイプがある事前に作成した PPTX を使用し、そのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) に *キャスト* しました。これが目的の OLE オブジェクトフレームです。  
4. OLE オブジェクトフレームにアクセスできたら、任意の操作を実行できます。  
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。  
6. 対象の `Worksheet` を取得し、データを修正します。  
7. 更新した `Workbook` をストリームに保存します。  
8. ストリームから OLE オブジェクトデータを置き換えます。

以下の例では、スライドに埋め込まれた OLE オブジェクトフレーム（Excel のグラフオブジェクト）にアクセスし、ファイルデータを変更してグラフデータを更新しています。
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// 最初のシェイプを OLE オブジェクトフレームとして取得します。
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

    // OLE フレームオブジェクトのデータを変更します。
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **スライドに他のファイルタイプを埋め込む**

Excel グラフに加えて、Aspose.Slides for C++ は HTML、PDF、ZIP などのファイルをオブジェクトとしてスライドに埋め込むことができます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連プログラムで自動的に開くか、適切なプログラムの選択を求められます。

以下の C++ コードは、HTML と ZIP をスライドに埋め込む方法を示しています:
```cpp
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

プレゼンテーションの作業中に、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされているものに置き換えたりする必要がある場合があります。Aspose.Slides for C++ では、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレームのデータや拡張子を更新できます。

以下の C++ コードは、埋め込まれた OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています:
``` cpp
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

OLE オブジェクトを埋め込むと、アイコン画像で構成されたプレビューが自動的に追加されます。これは、ユーザーがオブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビュー要素として使用したい場合は、Aspose.Slides for C++ でアイコン画像とタイトルを設定できます。

以下の C++ コードは、埋め込まれたオブジェクトのアイコン画像とタイトルを設定する方法を示しています:
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// プレゼンテーションリソースに画像を追加します。
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// OLE プレビュー用にタイトルと画像を設定します。
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **OLE オブジェクトフレームのサイズ変更と再配置を防止する**

リンクされた OLE オブジェクトをスライドに追加した後、PowerPoint でプレゼンテーションを開くと「リンクの更新」メッセージが表示されることがあります。「リンクの更新」ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトからデータを取得しプレビューを更新するため、OLE オブジェクトフレームのサイズや位置が変更されることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) インターフェイスの `set_UpdateAutomatic` メソッドを `false` に設定します:
```cpp
oleFrame->set_UpdateAutomatic(false);
```


## **埋め込みファイルの抽出**

Aspose.Slides for C++ を使用すると、スライドに OLE オブジェクトとして埋め込まれたファイルを次の手順で抽出できます。

1. 抽出対象の OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。  
2. プレゼンテーション内のすべてのシェイプをループし、[OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) シェイプにアクセスします。  
3. OLE オブジェクトフレームから埋め込まれたファイルのデータを取得し、ディスクに書き出します。

以下の C++ コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています:
``` cpp
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

**スライドを PDF や画像にエクスポートした場合、OLE コンテンツは描画されますか？**

スライド上に表示されているものが描画されます ― アイコンまたは代替画像（プレビュー）です。実際の「ライブ」OLE コンテンツはレンダリング時に実行されません。必要に応じて、期待通りの外観になるようプレビュー画像を自分で設定してください。

**スライド上の OLE オブジェクトをロックして、ユーザーが PowerPoint で移動/編集できないようにするには？**

シェイプレベルのロックを使用します。Aspose.Slides は [shape-level locks](/slides/ja/cpp/applying-protection-to-presentation/) を提供しています。これは暗号化ではありませんが、誤って編集や移動することを実質的に防止します。

**リンクされた Excel オブジェクトが「ジャンプ」したりサイズが変わったりするのはなぜですか？**

PowerPoint がリンクされた OLE のプレビューを更新するためです。安定した外観を保つには、[Worksheet Resizing の作業ソリューション](/slides/ja/cpp/working-solution-for-worksheet-resizing/) に従い、フレームを範囲に合わせるか、範囲を固定フレームにスケールし、適切な代替画像を設定してください。

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**

PPTX では「相対パス」情報は利用できず、フルパスのみが保存されます。相対パスは旧形式の PPT にのみ存在します。可搬性を確保するには、信頼できる絶対パスまたはアクセス可能な URI、または埋め込みを使用してください。