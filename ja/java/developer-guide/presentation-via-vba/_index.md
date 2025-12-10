---
title: JavaでプレゼンテーションのVBAプロジェクトを管理
linktitle: VBAによるプレゼンテーション
type: docs
weight: 250
url: /ja/java/presentation-via-vba/
keywords:
- マクロ
- VBA
- VBAマクロ
- マクロの追加
- マクロの削除
- マクロの抽出
- VBAの追加
- VBAの削除
- VBAの抽出
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して VBA 経由で PowerPoint および OpenDocument のプレゼンテーションを生成および操作し、ワークフローを効率化する方法をご紹介します。"
---

{{% alert title="Note" color="warning" %}} 

プレゼンテーションにマクロが含まれている状態で別のファイル形式（PDF、HTML、等）に変換すると、Aspose.Slides はすべてのマクロを無視します（マクロは結果のファイルに引き継がれません）。

プレゼンテーションにマクロを追加するか、マクロを含むプレゼンテーションを再保存すると、Aspose.Slides は単にマクロのバイトを記録します。

Aspose.Slides **決して** プレゼンテーション内のマクロを実行しません。

{{% /alert %}}

## **VBA マクロの追加**

Aspose.Slides は [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/) クラスを提供し、VBA プロジェクト（およびプロジェクト参照）の作成や既存モジュールの編集が可能です。プレゼンテーションに埋め込まれた VBA を管理するには [IVbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/ivbaproject/) インターフェイスを使用します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/#VbaProject--) コンストラクタを使用して新しい VBA プロジェクトを追加します。
1. VbaProject にモジュールを追加します。
1. モジュールのソースコードを設定します。
1. <stdole> への参照を追加します。
1. **Microsoft Office** への参照を追加します。
1. 参照を VBA プロジェクトに関連付けます。
1. プレゼンテーションを保存します。

この Java コードは、プレゼンテーションに VBA マクロをゼロから追加する方法を示しています:
```java
// プレゼンテーション クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 新しい VBA プロジェクトを作成
    pres.setVbaProject(new VbaProject());
    
    // VBA プロジェクトに空のモジュールを追加
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // モジュールのソースコードを設定
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // <stdole> への参照を作成
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Office への参照を作成
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // VBA プロジェクトに参照を追加
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // プレゼンテーションを保存
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 

**Aspose** の無料 Web アプリである [Macro Remover](https://products.aspose.app/slides/remove-macros) を確認してみてください。このアプリは PowerPoint、Excel、Word ドキュメントからマクロを削除します。

{{% /alert %}} 

## **VBA マクロの削除**

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスの [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getVbaProject--) プロパティを使用すると、VBA マクロを削除できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成し、マクロを含むプレゼンテーションを読み込みます。
1. マクロモジュールにアクセスし、削除します。
1. 変更したプレゼンテーションを保存します。

この Java コードは、VBA マクロを削除する方法を示しています:
```java
// マクロを含むプレゼンテーションをロードします
Presentation pres = new Presentation("VBA.pptm");
try {
    // Vba モジュールにアクセスして削除します 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // プレゼンテーションを保存します
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```


## **VBA マクロの抽出**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成し、マクロを含むプレゼンテーションを読み込みます。
2. プレゼンテーションに VBA プロジェクトが含まれているか確認します。
3. VBA プロジェクトに含まれるすべてのモジュールをループしてマクロを表示します。

この Java コードは、マクロを含むプレゼンテーションから VBA マクロを抽出する方法を示しています:
```java
// マクロを含むプレゼンテーションをロードします
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // プレゼンテーションに VBA プロジェクトが含まれているか確認します
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **VBA プロジェクトがパスワードで保護されているかの確認**

[IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) メソッドを使用すると、プロジェクトのプロパティがパスワードで保護されているかどうかを判断できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成し、マクロを含むプレゼンテーションを読み込みます。
2. プレゼンテーションに [VBA project](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/) が含まれているか確認します。
3. VBA プロジェクトがパスワードで保護されているかチェックし、プロパティを表示します。
```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // プレゼンテーションに VBA プロジェクトが含まれているか確認します。
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```


## **FAQ**

**プレゼンテーションを PPTX として保存した場合、マクロはどうなりますか？**

マクロは削除されます。PPTX は VBA をサポートしていないためです。マクロを保持したい場合は PPTM、PPSM、または POTM を選択してください。

**Aspose.Slides はプレゼンテーション内のマクロを実行して、たとえばデータを更新することができますか？**

いいえ。ライブラリは VBA コードを決して実行しません。実行は PowerPoint 内で適切なセキュリティ設定がある場合にのみ可能です。

**VBA コードにリンクされた ActiveX コントロールの操作はサポートされていますか？**

はい、既存の [ActiveX controls](/slides/ja/java/activex/) にアクセスし、プロパティを変更したり削除したりできます。これはマクロが ActiveX と連携する場合に便利です。