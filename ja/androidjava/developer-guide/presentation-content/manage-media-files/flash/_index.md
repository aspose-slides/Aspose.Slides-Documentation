---
title: フラッシュ
type: docs
weight: 10
url: /ja/androidjava/flash/
description: Javaを使用してPowerPointプレゼンテーションからフラッシュオブジェクトを抽出する
---

## **プレゼンテーションからフラッシュオブジェクトを抽出する**

Aspose.Slides for Android via Javaは、プレゼンテーションからフラッシュオブジェクトを抽出する機能を提供します。名前でフラッシュコントロールにアクセスし、プレゼンテーションから抽出し、SWFオブジェクトデータを保存できます。

```java
// PPTXを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```