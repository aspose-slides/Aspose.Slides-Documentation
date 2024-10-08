---
title: 在 Aspose.Slides 中获取字体替代的警告回调
type: docs
weight: 70
url: /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides for C++ 使得在渲染过程中，如果使用的字体在机器上不可用，可以获取字体替代的警告回调。警告回调在调试渲染过程中缺失或无法访问字体的问题时非常有帮助。

{{% /alert %}} 
## **获取字体替代的警告回调**
Aspose.Slides for C++ 提供了简单的 API 方法，以在渲染过程中获取警告回调。您只需遵循以下步骤在您的端配置警告回调：

1. 创建一个自定义回调类以接收回调。
1. 使用 [LoadOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options) 类设置警告回调。
1. 加载一个使用在目标机器上不可用的字体的演示文稿文件。
1. 生成幻灯片缩略图以查看效果。

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
        // "字体将从 X 替代为 Y"
        Console::WriteLine(warning->get_Description());

        return Warnings::ReturnAction::Continue;
    }
};
        
void Run()
{
    System::String dataDir = GetDataPath();

    // 设置警告回调
    System::SharedPtr<LoadOptions> options = System::MakeObject<LoadOptions>();
    options->set_WarningCallback(System::MakeObject<HandleFontsWarnings>());

    // 实例化演示文稿
    System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(dataDir + u"presentation.pptx", options);

    // 生成幻灯片缩略图
    for (auto slide : presentation->get_Slides())
    {
        System::SharedPtr<IImage> image = slide->GetImage();
    }
}
```