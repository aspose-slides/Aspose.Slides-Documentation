---
title: C++ でプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /ja/cpp/open-presentation/
keywords:
- PowerPoint を開く
- OpenDocument を開く
- プレゼンテーションを開く
- PPTX を開く
- PPT を開く
- ODP を開く
- プレゼンテーションを読み込む
- PPTX を読み込む
- PPT を読み込む
- ODP を読み込む
- 保護されたプレゼンテーション
- 大容量プレゼンテーション
- 外部リソース
- バイナリオブジェクト
- C++
- Aspose.Slides
description: "C++ で PowerPoint および OpenDocument プレゼンテーションを開き、開く際のパスワードを設定し、リソースの読み込みを制御し、Aspose.Slides for C++ を使用してメモリ使用量を削減する方法を学びます。"
---
## **はじめに**

[Aspose.Slides for C++](https://products.aspose.com/slides/ja/cpp/) は、ファイルやストリームから PowerPoint および OpenDocument プレゼンテーションを読み込むことができます。プレゼンテーションを読み込んだ後、その構造を検査したり、スライドを編集したり、リソースを管理したり、元の形式または別のサポートされている形式で保存したりできます。

読み込み動作は、[LoadOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/) クラスを使用してカスタマイズできます。たとえば、開く際のパスワードを指定したり、大きなバイナリ オブジェクトをメモリ外に保持したり、外部リソースを制御したり、埋め込みバイナリ データを省略したりできます。

## **プレゼンテーションを開く**

既存のプレゼンテーションを開くには、そのファイル パスを [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) コンストラクタに渡します。使用後はプレゼンテーションを破棄し、ファイルハンドル、テンポラリ データ、その他のリソースが速やかに解放されるようにします。

次の C++ の例は、プレゼンテーションを開いてスライド数を取得する方法を示しています。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **パスワード保護されたプレゼンテーションを開く**

開く際のパスワードはプレゼンテーションの内容を暗号化します。完全なプレゼンテーションを読み込むには、正しいパスワードを [LoadOptions::set_Password](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_password/) に渡し、オプションを [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) コンストラクタに渡します。パスワードがない、または間違っている場合は読み込みに失敗します。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

パスワード検出、検証、暗号化ワークフローについては、[Password‑Protect Presentations](/slides/ja/cpp/password-protected-presentation/) を参照してください。暗号化されたプレゼンテーションが意図的に公開ドキュメント プロパティと共に保存されている場合、そのプロパティはパスワードなしで読み取れます。詳細は [Manage Presentation Properties](/slides/ja/cpp/presentation-properties/) をご覧ください。

## **大容量プレゼンテーションを開く**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) は、画像、音声、動画などのバイナリ 大規模オブジェクト（BLOB）の取り扱い方法を制御します。ソース ファイルをロックしたままにしたり、テンポラリ ファイルを許可したり、メモリに保持する BLOB データの量を制限したりできます。

次の C++ コードは、大容量のプレゼンテーション（例: 2 GB）を読み込む方法を示しています。

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
`PresentationLockingBehavior::KeepLocked` を使用すると、`Presentation` オブジェクトが破棄されるまでソース ファイルはロックされたままになります。そのオブジェクトが存続している間は、ソース ファイルを移動、上書き、削除しないでください。

Aspose.Slides は、読み込み時に入力ストリームの内容をコピーすることがあります。大容量のプレゼンテーションの場合、ストリームよりもファイル パスの方が一般的に効率的です。ストレージやメモリ管理の追加オプションについては、[Manage BLOBs](/slides/ja/cpp/manage-blob/) を参照してください。
{{% /alert %}}

## **外部リソースの制御**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) は、[IResourceLoadingCallback](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iresourceloadingcallback/) の実装を受け取ります。コールバックは代替データを提供したり、リソースをリダイレクトしたり、デフォルトローダーを使用したり、リソースをスキップしたりできます。プレゼンテーションに外部画像が含まれ、アプリケーション固有のセキュリティやストレージ ルールに従って解決する必要がある場合に便利です。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **埋め込みバイナリオブジェクトなしでプレゼンテーションを読み込む**

プレゼンテーションには、アプリケーションが必要としない、または保持したくない埋め込みバイナリ データが含まれる場合があります。例としては、次のものがあります。

- VBA プロジェクト、[IPresentation::get_VbaProject](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_vbaproject/);
- 埋め込み OLE データ、[IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- ActiveX コントロール データ、[IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

[LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) に `true` を渡すと、読み込み時にこのバイナリ データが削除されます。サニタイズされた結果を保持するために、読み込んだプレゼンテーションを保存してください。

このオプションにより不要な埋め込みペイロードへの曝露は減少しますが、完全なマルウェア検出やコンテンツサニタイズ システムではありません。

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **よくある質問**

**ファイルが破損していて開けないことはどのように判断できますか？**

Aspose.Slides は読み込み中にパースまたはフォーマット例外をスローします。パスワードが間違っているエラーとは別にこの失敗を処理し、アプリケーションが原因を正確に報告できるようにします。

**必要なフォントが欠落している場合はどうなりますか？**

プレゼンテーションは依然として読み込めますが、レンダリングやエクスポート時にフォントが代替される可能性があります。出力をより予測可能にするために、[configure font substitution](/slides/ja/cpp/font-substitution/) または [provide custom fonts](/slides/ja/cpp/custom-font/) を使用できます。

**プレゼンテーションの読み込みは埋め込みメディアも読み込みますか？**

埋め込みの音声や動画はプレゼンテーション オブジェクト モデルを通じて利用可能になります。外部リソースは設定されたリソース読み込み動作に従って解決され、場所にアクセスできない場合は利用できないことがあります。