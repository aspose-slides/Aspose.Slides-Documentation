---
title: VBA マクロ
type: docs
weight: 150
url: /ja/androidjava/examples/elements/vba-macro/
keywords:
- コード例
- VBA
- マクロ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用してプレゼンテーションを自動化します。明確な Java の例を使って、PPT、PPTX、ODP で VBA マクロの作成、実行、インポート、保護を行います。"
---
この記事では、**Aspose.Slides for Android via Java** を使用して VBA マクロの追加、アクセス、削除方法を示します。

## **VBA マクロの追加**

VBA プロジェクトとシンプルなマクロモジュールを含むプレゼンテーションを作成します。

```java
static void addVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");
    } finally {
        presentation.dispose();
    }
}
```

## **VBA マクロへのアクセス**

VBA プロジェクトから最初のモジュールを取得します。

```java
static void accessVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        IVbaModule firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **VBA マクロの削除**

VBA プロジェクトからモジュールを削除します。

```java
static void removeVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.getVbaProject().getModules().remove(module);
    } finally {
        presentation.dispose();
    }
}
```