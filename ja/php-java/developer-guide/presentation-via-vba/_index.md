---
title: PHP を使用したプレゼンテーションでの VBA プロジェクトの管理
linktitle: VBA によるプレゼンテーション
type: docs
weight: 250
url: /ja/php-java/presentation-via-vba/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、VBA 経由で PowerPoint および OpenDocument プレゼンテーションを生成および操作し、ワークフローを効率化する方法をご紹介します。"
---

{{% alert title="Note" color="warning" %}} 

プレゼンテーションにマクロが含まれている状態で別のファイル形式（PDF、HTML など）に変換すると、Aspose.Slides はすべてのマクロを無視します（マクロは生成されたファイルに引き継がれません）。

プレゼンテーションにマクロを追加するか、マクロを含むプレゼンテーションを再保存すると、Aspose.Slides は単にマクロのバイト列を書き込みます。

Aspose.Slides はプレゼンテーション内のマクロを **決して** 実行しません。

{{% /alert %}}

## **VBA マクロの追加**

Aspose.Slides は [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/) クラスを提供し、VBA プロジェクト（およびプロジェクト参照）を作成したり既存のモジュールを編集したりできます。[IVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/ivbaproject/) インターフェイスを使用して、プレゼンテーションに埋め込まれた VBA を管理できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
2. 新しい VBA プロジェクトを追加するために [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#VbaProject--) コンストラクタを使用します。
3. VbaProject にモジュールを追加します。
4. モジュールのソースコードを設定します。
5. <stdole> への参照を追加します。
6. **Microsoft Office** への参照を追加します。
7. 参照を VBA プロジェクトに関連付けます。
8. プレゼンテーションを保存します。

この PHP コードは、プレゼンテーションに VBA マクロをゼロから追加する方法を示しています:
```php
  # プレゼンテーション クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 新しい VBA プロジェクトを作成します
    $pres->setVbaProject(new VbaProject());
    # VBA プロジェクトに空のモジュールを追加します
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # モジュールのソースコードを設定します
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # <stdole> への参照を作成します
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Office への参照を作成します
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # VBA プロジェクトに参照を追加します
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # プレゼンテーションを保存します
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 

**Aspose** の [Macro Remover](https://products.aspose.app/slides/remove-macros) は、PowerPoint、Excel、Word ドキュメントからマクロを削除するための無料ウェブアプリです。 

{{% /alert %}} 

## **VBA マクロの削除**

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスの下にある [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject--) プロパティを使用すると、VBA マクロを削除できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成し、マクロを含むプレゼンテーションを読み込みます。
2. マクロモジュールにアクセスし、削除します。
3. 変更後のプレゼンテーションを保存します。

この PHP コードは、VBA マクロを削除する方法を示しています:
```php
  # マクロを含むプレゼンテーションを読み込みます
  $pres = new Presentation("VBA.pptm");
  try {
    # Vba モジュールにアクセスして削除します
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # プレゼンテーションを保存します
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **VBA マクロの抽出**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成し、マクロを含むプレゼンテーションを読み込みます。
2. プレゼンテーションに VBA プロジェクトが含まれているか確認します。
3. VBA プロジェクトに含まれるすべてのモジュールをループして、マクロを表示します。

この PHP コードは、マクロを含むプレゼンテーションから VBA マクロを抽出する方法を示しています:
```php
  # マクロを含むプレゼンテーションを読み込みます
  $pres = new Presentation("VBA.pptm");
  try {
    # プレゼンテーションに VBA プロジェクトが含まれているか確認します
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **VBA プロジェクトがパスワードで保護されているか確認する**

[VbaProject.isPasswordProtected](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#isPasswordProtected) メソッドを使用すると、プロジェクトのプロパティがパスワードで保護されているかどうかを判断できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成し、マクロを含むプレゼンテーションを読み込みます。
2. プレゼンテーションに [VBA project](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/) が含まれているか確認します。
3. VBA プロジェクトがパスワードで保護されているか確認し、プロパティを表示します。
```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // プレゼンテーションに VBA プロジェクトが含まれているか確認します。
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**プレゼンテーションを PPTX 形式で保存した場合、マクロはどうなりますか？**

PPTX は VBA をサポートしていないため、マクロは削除されます。マクロを保持したい場合は、PPTM、PPSM、または POTM を選択してください。

**Aspose.Slides はプレゼンテーション内のマクロを実行してデータを更新するなどできますか？**

できません。ライブラリは決して VBA コードを実行せず、実行は適切なセキュリティ設定がされた PowerPoint 内でのみ可能です。

**VBA コードにリンクされた ActiveX コントロールの操作はサポートされていますか？**

はい、既存の [ActiveX controls](/slides/ja/php-java/activex/) にアクセスし、プロパティを変更したり削除したりできます。これは、マクロが ActiveX と連携する場合に便利です。