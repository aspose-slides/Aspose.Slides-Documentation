---
title: フラッシュ
type: docs
weight: 10
url: /cpp/flash/
---

## **プレゼンテーションからフラッシュオブジェクトを抽出する**
Aspose.Slides for C++ は、プレゼンテーションからフラッシュオブジェクトを抽出する機能を提供します。名前でフラッシュコントロールにアクセスし、プレゼンテーションから抽出し、SWFオブジェクトデータを含めることができます。

``` cpp
auto pres = System::MakeObject<Presentation>(u"withFlash.pptm");
auto controls = pres->get_Slides()->idx_get(0)->get_Controls();
System::SharedPtr<Control> flashControl;
for (const auto& control : controls)
{
    if (control->get_Name() == u"ShockwaveFlash1")
    {
        flashControl = System::ExplicitCast<Control>(control);
    }
}
```