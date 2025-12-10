---
title: C++でプレゼンテーションを開く
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
description: "Aspose.Slides for C++ を使用して、PowerPoint (.pptx、.ppt) および OpenDocument (.odp) プレゼンテーションを簡単に開く—高速で信頼性が高く、フル機能です。"
---

## **概要**

PowerPoint のプレゼンテーションを最初から作成するだけでなく、Aspose.Slides は既存のプレゼンテーションを開くこともできます。プレゼンテーションを読み込んだ後、情報を取得したり、スライドの内容を編集したり、新しいスライドを追加したり、既存のスライドを削除したりできます。

## **プレゼンテーションを開く**

既存のプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスをインスタンス化し、コンストラクタにファイルパスを渡します。

以下の C++ の例は、プレゼンテーションを開いてスライド数を取得する方法を示しています。
```cpp
// Presentation クラスをインスタンス化し、コンストラクタにファイルパスを渡します。
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// プレゼンテーション内のスライド総数を出力します。
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```


## **パスワードで保護されたプレゼンテーションを開く**

パスワードで保護されたプレゼンテーションを開く必要がある場合は、[LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) クラスの [set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) メソッドにパスワードを渡して復号し、読み込みます。以下の C++ コードがこの操作を示しています。
```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// 復号化されたプレゼンテーションで操作を実行します。

presentation->Dispose();
```


## **大容量プレゼンテーションを開く**

Aspose.Slides は、大容量プレゼンテーションの読み込みを支援するオプションを提供します。特に、[LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) クラスの [get_BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) メソッドが有用です。

以下の C++ コードは、たとえば 2 GB の大容量プレゼンテーションを読み込む例です。
```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// KeepLocked 動作を選択します—プレゼンテーション ファイルは
// Presentation インスタンスの存続期間中ロックされたままになりますが、メモリにロードしたり一時ファイルにコピーしたりする必要はありません。
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// 大容量プレゼンテーションがロードされ、使用できます。メモリ消費は低く抑えられます。

// プレゼンテーションを変更します。
presentation->get_Slide(0)->set_Name(u"Large presentation");

// プレゼンテーションを別のファイルに保存します。この操作中もメモリ消費は低く保たれます。
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// これを実行しないでください！プレゼンテーション オブジェクトが破棄されるまでファイルがロックされているため、I/O 例外がスローされます。
File::Delete(filePath);

presentation->Dispose();

// ここで実行しても問題ありません。ソース ファイルはプレゼンテーション オブジェクトによってロックされていません。
File::Delete(filePath);
```


{{% alert color="info" title="情報" %}}

ストリームを扱う際の特定の制限を回避するために、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームから大容量プレゼンテーションを読み込むと、プレゼンテーションがコピーされ、読み込みが遅くなる可能性があります。したがって、大容量プレゼンテーションを読み込む必要がある場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強く推奨します。

動画、音声、高解像度画像などの大きなオブジェクトを含むプレゼンテーションを作成する際は、[BLOB management](/slides/ja/cpp/manage-blob/) を使用してメモリ消費を抑えることができます。

{{%/alert %}}

## **外部リソースの制御**

Aspose.Slides は、外部リソースを管理できる [IResourceLoadingCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iresourceloadingcallback/) インターフェイスを提供します。以下の C++ コードは、`IResourceLoadingCallback` インターフェイスの使用方法を示しています。
```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // 代替画像を読み込む。
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // 代替 URL を設定する。
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // 他のすべての画像をスキップする。
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```


## **埋め込みバイナリオブジェクトなしでプレゼンテーションを読み込む**

PowerPoint プレゼンテーションには、次の種類の埋め込みバイナリオブジェクトが含まれることがあります。

- VBA プロジェクト（[IPresentation::get_VbaProject](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_vbaproject/) で取得可能）;
- OLE オブジェクトの埋め込みデータ（[IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/) で取得可能）;
- ActiveX コントロールのバイナリデータ（[IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_activexcontrolbinary/) で取得可能）。

[ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/) メソッドを使用すると、埋め込みバイナリオブジェクトを一切含まない状態でプレゼンテーションを読み込むことができます。

このメソッドは、潜在的に悪意のあるバイナリコンテンツを除去する際に便利です。以下の C++ コードは、埋め込みバイナリコンテンツなしでプレゼンテーションを読み込む例です。
```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Perform operations on the presentation.

presentation->Dispose();
```


## **FAQ**

**ファイルが破損していて開けないことをどのように判断できますか？**

読み込み時に解析/形式検証例外がスローされます。この種のエラーは、無効な ZIP 構造や破損した PowerPoint レコードに言及することが多いです。

**開く際に必須フォントが欠如している場合はどうなりますか？**

ファイルは開きますが、後続の [rendering/export](/slides/ja/cpp/convert-presentation/) 時にフォントが置き換えられる可能性があります。実行環境にフォント置換を設定するか、[Configure font substitutions](/slides/ja/cpp/font-substitution/) または [add the required fonts](/slides/ja/cpp/custom-font/) を追加してください。

**開く際の埋め込みメディア（動画/音声）についてはどうですか？**

メディアはプレゼンテーションリソースとして利用可能になります。外部パスで参照されているメディアがある場合は、そのパスが環境でアクセス可能であることを確認してください。そうでないと、[rendering/export](/slides/ja/cpp/convert-presentation/) 時にメディアが省略されることがあります。