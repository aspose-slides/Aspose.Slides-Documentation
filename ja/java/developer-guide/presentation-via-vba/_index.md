---
title: VBAを使ったプレゼンテーション
type: docs
weight: 250
url: /java/presentation-via-vba/
keywords: "マクロ, マクロ, VBA, VBAマクロ, マクロ追加, マクロ削除, VBA追加, VBA削除, マクロを抽出, VBAを抽出, PowerPointマクロ, PowerPointプレゼンテーション, Java, Aspose.Slides for Java"
description: "JavaでPowerPointプレゼンテーションにVBAマクロを追加、削除、抽出する"
---

{{% alert title="注意" color="warning" %}} 

マクロを含むプレゼンテーションを別のファイル形式（PDF、HTMLなど）に変換すると、Aspose.Slidesはすべてのマクロを無視します（結果として生成されるファイルにはマクロが含まれません）。

プレゼンテーションにマクロを追加するか、マクロを含むプレゼンテーションを再保存すると、Aspose.Slidesは単にマクロのバイトを書き込むだけです。

Aspose.Slides **は決して** プレゼンテーション内のマクロを実行しません。

{{% /alert %}}

## **VBAマクロを追加する**

Aspose.Slidesは、VBAプロジェクトを作成（およびプロジェクト参照を設定）し、既存のモジュールを編集するための[VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/)クラスを提供します。[IVbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/ivbaproject/)インターフェースを使用して、プレゼンテーションに埋め込まれたVBAを管理することができます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/#VbaProject--)コンストラクタを使用して新しいVBAプロジェクトを追加します。
1. VbaProjectにモジュールを追加します。
1. モジュールのソースコードを設定します。
1. <stdole>への参照を追加します。
1. **Microsoft Office**への参照を追加します。
1. 参照をVBAプロジェクトに関連付けます。
1. プレゼンテーションを保存します。

このJavaコードは、プレゼンテーションにゼロからVBAマクロを追加する方法を示しています：

```java
// プレゼンテーションクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 新しいVBAプロジェクトを作成
    pres.setVbaProject(new VbaProject());
    
    // VBAプロジェクトに空のモジュールを追加
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // モジュールのソースコードを設定
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // <stdole>への参照を作成
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Officeへの参照を作成
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // VBAプロジェクトに参照を追加
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // プレゼンテーションを保存
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

**Aspose**の[マクロ除去ツール](https://products.aspose.app/slides/remove-macros)をチェックしてみると良いでしょう。これはPowerPoint、Excel、Word文書からマクロを削除するための無料ウェブアプリです。

{{% /alert %}} 

## **VBAマクロを削除する**

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスの[VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getVbaProject--)プロパティを使用して、VBAマクロを削除できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成し、マクロを含むプレゼンテーションをロードします。
1. マクロモジュールにアクセスし、それを削除します。
1. 修正されたプレゼンテーションを保存します。

このJavaコードは、VBAマクロを削除する方法を示しています：

```java
// マクロを含むプレゼンテーションをロード
Presentation pres = new Presentation("VBA.pptm");
try {
    // Vbaモジュールにアクセスし、それを削除
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // プレゼンテーションを保存
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **VBAマクロを抽出する**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成し、マクロを含むプレゼンテーションをロードします。
2. プレゼンテーションにVBAプロジェクトが含まれているか確認します。
3. VBAプロジェクトに含まれるすべてのモジュールをループしてマクロを表示します。

このJavaコードは、マクロを含むプレゼンテーションからVBAマクロを抽出する方法を示しています：

```java
// マクロを含むプレゼンテーションをロード
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // プレゼンテーションにVBAプロジェクトが含まれているか確認
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