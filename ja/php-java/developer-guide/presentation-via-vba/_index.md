---
title: VBAを使用したプレゼンテーション
type: docs
weight: 250
url: /php-java/presentation-via-vba/
keywords: "マクロ, マクロ, VBA, VBAマクロ, マクロを追加, マクロを削除, VBAを追加, VBAを削除, マクロを抽出, VBAを抽出, PowerPointマクロ, PowerPointプレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "PowerPointプレゼンテーションのVBAマクロを追加、削除、抽出します"
---

{{% alert title="注意" color="warning" %}} 

マクロを含むプレゼンテーションを異なるファイル形式（PDF、HTMLなど）に変換すると、Aspose.Slidesはすべてのマクロを無視します（マクロは結果のファイルに持ち込まれません）。

プレゼンテーションにマクロを追加したり、マクロを含むプレゼンテーションを再保存したりすると、Aspose.Slidesは単にマクロのバイトを記述します。

Aspose.Slidesは**決して**プレゼンテーション内のマクロを実行しません。

{{% /alert %}}

## **VBAマクロの追加**

Aspose.Slidesは、[VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/)クラスを提供しており、VBAプロジェクト（およびプロジェクト参照）を作成し、既存のモジュールを編集できます。[IVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/ivbaproject/)インターフェースを使用して、プレゼンテーションに埋め込まれたVBAを管理できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
1. [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#VbaProject--)コンストラクターを使用して新しいVBAプロジェクトを追加します。
1. VbaProjectにモジュールを追加します。
1. モジュールのソースコードを設定します。
1. <stdole>への参照を追加します。
1. **Microsoft Office**への参照を追加します。
1. 参照をVBAプロジェクトに関連付けます。
1. プレゼンテーションを保存します。

このPHPコードは、プレゼンテーションにVBAマクロをゼロから追加する方法を示しています：

```php
  # プレゼンテーションクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 新しいVBAプロジェクトを作成
    $pres->setVbaProject(new VbaProject());
    # VBAプロジェクトに空のモジュールを追加
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # モジュールのソースコードを設定
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # <stdole>への参照を作成
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Officeへの参照を作成
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # VBAプロジェクトに参照を追加
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # プレゼンテーションを保存
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

**Aspose**の[マクロ削除ツール](https://products.aspose.app/slides/remove-macros)をチェックしてみてください。これは、PowerPoint、Excel、およびWord文書からマクロを削除するために使用される無料のWebアプリです。 

{{% /alert %}} 

## **VBAマクロの削除**

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスの[VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject--)プロパティを使用して、VBAマクロを削除できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成し、マクロを含むプレゼンテーションをロードします。
1. マクロモジュールにアクセスして削除します。
1. 修正されたプレゼンテーションを保存します。

このPHPコードは、VBAマクロを削除する方法を示しています：

```php
  # マクロを含むプレゼンテーションを読み込む
  $pres = new Presentation("VBA.pptm");
  try {
    # Vbaモジュールにアクセスして削除
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # プレゼンテーションを保存
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **VBAマクロの抽出**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成し、マクロを含むプレゼンテーションをロードします。
2. プレゼンテーションにVBAプロジェクトが含まれているか確認します。
3. VBAプロジェクトに含まれるすべてのモジュールをループしてマクロを表示します。

このPHPコードは、マクロを含むプレゼンテーションからVBAマクロを抽出する方法を示しています：

```php
  # マクロを含むプレゼンテーションを読み込む
  $pres = new Presentation("VBA.pptm");
  try {
    # プレゼンテーションがVBAプロジェクトを含むか確認
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