---
title: Java を使用してプレゼンテーションの VBA プロジェクトを管理する
linktitle: VBA を使用したプレゼンテーション
type: docs
weight: 250
url: /ja/java/presentation-via-vba/
keywords:
- マクロ
- VBA
- VBA マクロ
- マクロの追加
- マクロの削除
- マクロの抽出
- VBA の追加
- VBA の削除
- VBA の抽出
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して VBA 経由で PowerPoint および OpenDocument プレゼンテーションを生成および操作し、ワークフローを効率化する方法をご紹介します。"
---
## **導入**

Aspose.Slides はマクロと VBA コードを操作するためのクラスとインターフェイスを提供します。

{{% alert title="Note" color="warning" %}} 

プレゼンテーションにマクロが含まれている状態で別のファイル形式 (PDF、HTML など) に変換すると、Aspose.Slides はすべてのマクロを無視します (マクロは生成されたファイルに引き継がれません)。

プレゼンテーションにマクロを追加するか、マクロを含むプレゼンテーションを再保存すると、Aspose.Slides は単にマクロのバイト列を書き込みます。

Aspose.Slides はプレゼンテーション内のマクロを **決して** 実行しません。

{{% /alert %}}

## **VBA マクロの追加**

Aspose.Slides は [VbaProject](https://reference.aspose.com/slides/ja/java/com.aspose.slides/vbaproject/) クラスを提供し、VBA プロジェクト (およびプロジェクト参照) の作成と既存モジュールの編集が可能です。また、[IVbaProject](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivbaproject/) インターフェイスを使用して、プレゼンテーションに埋め込まれた VBA を管理できます。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
1. [VbaProject](https://reference.aspose.com/slides/ja/java/com.aspose.slides/vbaproject/#VbaProject--) コンストラクタを使用して新しい VBA プロジェクトを追加します。  
1. VbaProject にモジュールを追加します。  
1. モジュールのソースコードを設定します。  
1. <stdole> への参照を追加します。  
1. **Microsoft Office** への参照を追加します。  
1. 参照を VBA プロジェクトに関連付けます。  
1. プレゼンテーションを保存します。

この Java コードは、プレゼンテーションに VBA マクロをゼロから追加する方法を示しています。

```java
import com.aspose.slides.*;

// プレゼンテーションクラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 新しい VBA プロジェクトを作成します
    pres.setVbaProject(new VbaProject());
    
    // VBA プロジェクトに空のモジュールを追加します
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // モジュールのソースコードを設定します
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // <stdole> への参照を作成します
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Office への参照を作成します
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // VBA プロジェクトに参照を追加します
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // プレゼンテーションを保存します
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

**Aspose** の無料ウェブアプリ **[Macro Remover](https://products.aspose.app/slides/ja/remove-macros)** を使って、PowerPoint、Excel、Word 文書からマクロを削除できます。 

{{% /alert %}} 

## **VBA マクロの削除**

[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスの [VbaProject](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getVbaProject--) プロパティを使用すると、VBA マクロを削除できます。

1. マクロを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
1. マクロ モジュールにアクセスし、削除します。  
1. 変更したプレゼンテーションを保存します。

この Java コードは、VBA マクロを削除する方法を示しています。

```java
import com.aspose.slides.*;

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

1. マクロを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. プレゼンテーションに VBA プロジェクトが含まれているか確認します。  
3. VBA プロジェクトに含まれるすべてのモジュールをループして、マクロを表示します。

この Java コードは、マクロを含むプレゼンテーションから VBA マクロを抽出する方法を示しています。

```java
import com.aspose.slides.*;

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

[IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) メソッドを使用して、プロジェクトのプロパティがパスワードで保護されているかどうかを判断できます。

1. マクロを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. プレゼンテーションに [VBA project](https://reference.aspose.com/slides/ja/java/com.aspose.slides/vbaproject/) が含まれているか確認します。  
3. VBA プロジェクトがパスワードで保護されているか確認し、プロパティを表示できるか確認します。

```java
import com.aspose.slides.*;

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

### プレゼンテーションを PPTX 形式で保存するとマクロはどうなりますか？

PPTX は VBA をサポートしないため、マクロは削除されます。マクロを保持したい場合は PPTM、PPSM、または POTM を選択してください。

### Aspose.Slides はプレゼンテーション内のマクロを実行してデータを更新できますか？

できません。ライブラリは VBA コードを実行せず、実行は適切なセキュリティ設定がされた PowerPoint 内でのみ可能です。

### VBA コードにリンクした ActiveX コントロールの操作はサポートされていますか？

はい。既存の [ActiveX controls](/slides/ja/java/activex/) にアクセスし、プロパティを変更したり削除したりできます。マクロが ActiveX と連携する場合に便利です。