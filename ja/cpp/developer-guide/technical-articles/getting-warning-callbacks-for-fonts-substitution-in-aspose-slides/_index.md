---
title: フォントの置き換えに関する警告コールバックの取得方法 in Aspose.Slides
type: docs
weight: 70
url: /ja/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides for C++ は、レンダリングプロセス中に使用されるフォントがマシンで利用できない場合に、フォントの置き換えに関する警告コールバックを取得することを可能にします。警告コールバックは、レンダリングプロセス中に欠落している、またはアクセスできないフォントに関する問題をデバッグする際に役立ちます。

{{% /alert %}} 
## **フォントの置き換えに関する警告コールバックの取得**
Aspose.Slides for C++ は、レンダリングプロセス中に警告コールバックを取得するためのシンプルなAPIメソッドを提供しています。以下の手順に従って、あなたの環境で警告コールバックを構成する必要があります:

1. コールバックを受信するためのカスタムコールバッククラスを作成します。
1. [LoadOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options) クラスを使用して、警告コールバックを設定します。
1. ターゲットマシンで利用できないフォントを使用しているプレゼンテーションファイルをロードします。
1. スライドサムネイルを生成して、その効果を確認します。

``` cpp
class HandleFontsWarnings : public Warnings::IWarningCallback
{
public:
    Warnings::ReturnAction Warning(SharedPtr<Warnings::IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == Warnings::WarningType::CompatibilityIssue)
        {
            return Warnings::ReturnAction::Continue;
        }

        // 1 - WarningType.DataLoss
        Console::WriteLine(System::ObjectExt::ToString(warning->get_WarningType()));
        // "フォントがXからYに置き換えられます"
        Console::WriteLine(warning->get_Description());

        return Warnings::ReturnAction::Continue;
    }
};
        
void Run()
{
    System::String dataDir = GetDataPath();

    // 警告コールバックの設定
    System::SharedPtr<LoadOptions> options = System::MakeObject<LoadOptions>();
    options->set_WarningCallback(System::MakeObject<HandleFontsWarnings>());

    // プレゼンテーションのインスタンス化
    System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(dataDir + u"presentation.pptx", options);

    // スライドサムネイルの生成
    for (auto slide : presentation->get_Slides())
    {
        System::SharedPtr<IImage> image = slide->GetImage();
    }
}
```