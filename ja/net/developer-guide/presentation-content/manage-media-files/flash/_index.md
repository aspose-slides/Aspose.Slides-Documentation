---
title: フラッシュ
type: docs
weight: 10
url: /ja/net/flash/
keywords: "フラッシュの抽出, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションからフラッシュオブジェクトを抽出する"
---

## **プレゼンテーションからフラッシュオブジェクトを抽出する**
Aspose.Slides for .NET は、プレゼンテーションからフラッシュオブジェクトを抽出する機能を提供します。名前でフラッシュコントロールにアクセスし、プレゼンテーションから抽出し、SWFオブジェクトデータを保存できます。

```c#
using (Presentation pres = new Presentation("withFlash.pptm"))
{
    IControlCollection controls = pres.Slides[0].Controls;
    Control flashControl = null;
    foreach (IControl control in controls)
    {
        if (control.Name == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
}
```