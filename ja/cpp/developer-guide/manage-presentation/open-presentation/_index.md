---
title: プレゼンテーションを開く - C++ PowerPoint API
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /cpp/open-presentation/
keywords: "PowerPointを開く, PPTX, PPT, プレゼンテーションを開く, プレゼンテーションをロード, C++, CPP"
description: "C++でプレゼンテーションPPT、PPTX、ODPを開くまたはロードする"
---

PowerPointプレゼンテーションをゼロから作成するだけでなく、Aspose.Slidesを使用すると、既存のプレゼンテーションを開くことができます。プレゼンテーションをロードした後、そのプレゼンテーションに関する情報を取得したり、プレゼンテーションの内容を編集したり、新しいスライドを追加したり既存のスライドを削除したりすることができます。 

## プレゼンテーションを開く

既存のプレゼンテーションを開くには、単に[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスをインスタンス化し、開きたいプレゼンテーションのファイルパスをコンストラクタに渡すだけです。

このC++コードは、プレゼンテーションをどう開くか、またその中に含まれているスライドの数を見つける方法を示しています: 

```c++
// ドキュメントディレクトリへのパス
String dataDir = u"";

// Presentationクラスをインスタンス化し、ファイルパスをコンストラクタに渡す
auto pres = System::MakeObject<Presentation>(dataDir + u"OpenPresentation.pptx");

// プレゼンテーション内に存在するスライドの総数を印刷
Console::WriteLine(Convert::ToString(pres->get_Slides()->get_Count()));
```

## **パスワード保護されたプレゼンテーションを開く**

パスワード保護されたプレゼンテーションを開く必要がある場合は、[get_Password()](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/get_password/)プロパティ（[LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/)クラスから）を通じてパスワードを渡して、プレゼンテーションを復号化し、ロードすることができます。このC++コードはその操作を示しています:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);
// 復号化されたプレゼンテーションで何らかの作業を行う
```

## 大きなプレゼンテーションを開く

Aspose.Slidesは、[LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/)クラス内の[BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/)プロパティを特に利用して、大きなプレゼンテーションをロードできるオプションを提供しています。

このC++コードは、サイズが2GBの大きなプレゼンテーションをロードする操作を示しています:

```c++
String pathToVeryLargePresentationFile = u"veryLargePresentation.pptx";

{
    SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
    // クロージャを選択しましょう - "veryLargePresentation.pptx"はプレゼンテーションのインスタンスライフタイムの間ロックされますが、
    // メモリにロードしたり、一時ファイルにコピーしたりする必要はありません
    loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

    auto pres = System::MakeObject<Presentation>(pathToVeryLargePresentationFile, loadOptions);

    // 大きなプレゼンテーションがロードされ、使用可能ですが、メモリ使用量はまだ低いままです。

    // プレゼンテーションを変更します。
    pres->get_Slides()->idx_get(0)->set_Name(u"非常に大きなプレゼンテーション");

    // プレゼンテーションは別のファイルに保存されます。操作中はメモリの消費は低いままです
    pres->Save(u"veryLargePresentation-copy.pptx", SaveFormat::Pptx);

    // それはできません！ファイルはロックされているためIO例外が発生しますが、presオブジェクトは
    // 解放されません
    File::Delete(pathToVeryLargePresentationFile);
}

// ここで行うのは問題ありません。ソースファイルはpresオブジェクトによってロックされていません
File::Delete(pathToVeryLargePresentationFile);
```

{{% alert color="info" title="情報" %}}

ストリームとのやりとりに関する特定の制限を回避するために、Aspose.Slidesはストリームの内容をコピーする場合があります。ストリームを介して大きなプレゼンテーションをロードすると、プレゼンテーションの内容がコピーされ、ロードが遅くなる原因となります。したがって、大きなプレゼンテーションをロードする場合は、ストリームではなくプレゼンテーションファイルパスを使用することを強くお勧めします。

大きなオブジェクト（ビデオ、オーディオ、大サイズの画像など）を含むプレゼンテーションを作成したい場合は、[Blob機能](https://docs.aspose.com/slides/cpp/manage-blob/)を使用してメモリ消費を抑えることができます。

{{%/alert %}} 

## プレゼンテーションをロードする

Aspose.Slidesは、外部リソースを管理するために単独のメソッドを持つ[IResourceLoadingCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iresourceloadingcallback/)を提供します。このC++コードは、`IResourceLoadingCallback`インターフェースを使用する方法を示しています:

```c++
// ドキュメントディレクトリへのパス
System::String dataDir = GetDataPath();

auto opts = System::MakeObject<LoadOptions>();
opts->set_ResourceLoadingCallback(System::MakeObject<ImageLoadingHandler>(dataDir));
auto presentation = System::MakeObject<Presentation>(dataDir + u"presentation.pptx", opts);
```

```c++
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ImageLoadingHandler(String dataDir)
        : m_dataDir(dataDir)
    {
    }

    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                System::ArrayPtr<uint8_t> imageBytes = File::ReadAllBytes(Path::Combine(m_dataDir, u"aspose-logo.jpg"));
                args->SetData(imageBytes);
                return ResourceLoadingAction::UserProvided;
            }
            catch (System::Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }

        if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // 代替のURLを設定します
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // 他のすべての画像をスキップします
        return ResourceLoadingAction::Skip;
    }
    
private:
    String m_dataDir;
};
```

<h2>プレゼンテーションのオープンと保存</h2>

<a name="cplusplus-open-save-presentation"><strong>手順：C++でプレゼンテーションを開いて保存する</strong></a>

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成し、開きたいファイルを渡します。 

2. プレゼンテーションを保存します。 

   ```c++
   	const String outPath = u"../out/SaveToFile_out.ppt";
   	
   	SharedPtr<Presentation> pres = MakeObject<Presentation>();
   
   	// pres->get_ProtectionManager()->Encrypt(u"pass");
   	// ...ここで何らかの作業を行います..
   
   	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
   ```