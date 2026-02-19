---
title: VBA マクロ
type: docs
weight: 150
url: /ja/java/examples/elements/vba-macro/
keywords:
- コード例
- VBA
- マクロ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用してプレゼンテーションを自動化します。PPT、PPTX、ODP で VBA マクロを作成、実行、インポート、保護する明確な Java のサンプルです。"
---
この記事では、**Aspose.Slides for Java** を使用して VBA マクロを追加、アクセス、削除する方法を示します。

## **VBAマクロの追加**

VBA プロジェクトとシンプルなマクロ モジュールを含むプレゼンテーションを作成します。

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

## **VBAマクロへのアクセス**

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

## **VBAマクロの削除**

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