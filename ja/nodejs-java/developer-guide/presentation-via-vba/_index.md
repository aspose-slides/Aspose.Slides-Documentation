---
title: VBAによるプレゼンテーション
type: docs
weight: 250
url: /ja/nodejs-java/presentation-via-vba/
keywords: "マクロ, マクロ, VBA, VBAマクロ, マクロを追加, マクロを削除, VBAを追加, VBAを削除, マクロを抽出, VBAを抽出, PowerPointマクロ, PowerPointプレゼンテーション, Java, Node.js 用 Aspose.Slides (Java 経由)"
description: "JavaScript で PowerPoint プレゼンテーションの VBA マクロを追加、削除、抽出する"
---

{{% alert title="Note" color="warning" %}} 

マクロを含むプレゼンテーションを別のファイル形式（PDF、HTML など）に変換すると、Aspose.Slides はすべてのマクロを無視します（マクロは生成されたファイルに引き継がれません）。

プレゼンテーションにマクロを追加したり、マクロを含むプレゼンテーションを再保存した場合、Aspose.Slides は単にマクロのバイト列を書き込みます。

Aspose.Slides はプレゼンテーション内のマクロを **決して** 実行しません。

{{% /alert %}}

## **VBA マクロの追加**

Aspose.Slides は [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/) クラスを提供し、VBA プロジェクト（およびプロジェクト参照）の作成や既存モジュールの編集が可能です。プレゼンテーションに埋め込まれた VBA を管理するために [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/) クラスを使用できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/#VbaProject--) コンストラクターを使用して新しい VBA プロジェクトを追加します。
1. VbaProject にモジュールを追加します。
1. モジュールのソースコードを設定します。
1. <stdole> への参照を追加します。
1. **Microsoft Office** への参照を追加します。
1. 参照を VBA プロジェクトに関連付けます。
1. プレゼンテーションを保存します。

この JavaScript コードは、プレゼンテーションに VBA マクロをゼロから追加する方法を示しています:
```javascript
// プレゼンテーション クラスのインスタンスを作成します
let pres = new aspose.slides.Presentation();
try {
    // 新しい VBA プロジェクトを作成します
    pres.setVbaProject(new aspose.slides.VbaProject());
    // VBA プロジェクトに空のモジュールを追加します
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // モジュールのソースコードを設定します
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // <stdole> への参照を作成します
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // Office への参照を作成します
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // VBA プロジェクトに参照を追加します
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // プレゼンテーションを保存します
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

無料の Web アプリである **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros) を利用すれば、PowerPoint、Excel、Word ドキュメントからマクロを削除できます。

{{% /alert %}} 

## **VBA マクロの削除**

[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスの [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getVbaProject--) プロパティを使用して、VBA マクロを削除できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成し、マクロを含むプレゼンテーションを読み込みます。
1. マクロモジュールにアクセスし、削除します。
1. 変更したプレゼンテーションを保存します。

この JavaScript コードは、VBA マクロを削除する方法を示しています:
```javascript
// マクロを含むプレゼンテーションを読み込みます
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Vba モジュールにアクセスして削除します
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // プレゼンテーションを保存します
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **VBA マクロの抽出**

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成し、マクロを含むプレゼンテーションを読み込みます。
2. プレゼンテーションに VBA プロジェクトが含まれているか確認します。
3. VBA プロジェクトに含まれるすべてのモジュールをループしてマクロを表示します。

この JavaScript コードは、マクロを含むプレゼンテーションから VBA マクロを抽出する方法を示しています:
```javascript
// マクロを含むプレゼンテーションを読み込みます
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // プレゼンテーションに VBA プロジェクトが含まれているか確認します
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **VBA プロジェクトがパスワードで保護されているかの確認**

[VbaProject.isPasswordProtected](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/#isPasswordProtected) メソッドを使用すると、プロジェクトのプロパティがパスワードで保護されているかどうかを判断できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成し、マクロを含むプレゼンテーションを読み込みます。
2. プレゼンテーションに [VBA プロジェクト](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/) が含まれているか確認します。
3. VBA プロジェクトがパスワードで保護されているか確認し、プロパティを表示します。
```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // プレゼンテーションに VBA プロジェクトが含まれているか確認します。
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```


## **FAQ**

**プレゼンテーションを PPTX 形式で保存した場合、マクロはどうなりますか？**

PPTX は VBA をサポートしていないため、マクロは削除されます。マクロを保持したい場合は PPTM、PPSM、または POTM を選択してください。

**Aspose.Slides はプレゼンテーション内のマクロを実行してデータを更新できますか？**

できません。ライブラリは VBA コードを決して実行せず、実行は適切なセキュリティ設定がされた PowerPoint 内でのみ可能です。

**VBA コードにリンクされた ActiveX コントロールの操作はサポートされていますか？**

はい、既存の [ActiveX controls](/slides/ja/nodejs-java/activex/) にアクセスし、プロパティを変更したり削除したりできます。これはマクロが ActiveX と連携する場合に有用です。