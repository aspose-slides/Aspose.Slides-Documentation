---
title: Aspose.Slides for PHP via Java 14.8.0における公開APIと後方互換性のない変更
type: docs
weight: 70
url: /ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for PHP via Java 14.8.0 APIで追加されたすべての[class](/slides/ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/)クラス、メソッド、プロパティ、新しい制限、およびその他の[changes](/slides/ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/)をリストします。

{{% /alert %}} 
## **公開APIの変更**
### **Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap(), および setOverlap(byte) メソッドを追加**
Aspose.Slides.Charts.IChartSeries.getOverlap()は、2Dグラフにおいてバーやカラムがどれだけ重なるべきかを取得します（-100から100の範囲で）。
このメソッドは特定の系列だけでなく、親系列グループのすべての系列に対しても使用でき、これは適切なグループプロパティの投影です。

- 親系列グループにアクセスするには、IChartSeries.getParentSeriesGroup() メソッドを使用してください。
- 値を管理するには、IChartSeriesGroup.getOverlap() および setOverlap(byte) メソッドを使用してください。

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
  $series = $chart->getChartData()->getSeries();
  if (java_values($series->get_Item(0)->getOverlap()) == 0) {
    $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
  }
```
### **ShapeThumbnailBounds.Appearance 列挙値を追加**
この形状サムネイルを作成するメソッドは、開発者が外観の境界内で形状サムネイルを生成することを可能にします。これはすべての形状効果を考慮に入れています。生成された形状サムネイルはスライドの境界によって制限されます。

```php
  $pres = new Presentation();
  $st = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail(ShapeThumbnailBounds->Appearance, 1, 1);
```
### **VbaProject クラスと IVbaProject インターフェイスを追加、Presentation.getVbaProject() および setVbaProject(VbaProject) メソッドを変更**
新機能により、開発者はプレゼンテーション内でVBAプロジェクトを作成および編集することが可能になります。

```php
  $pres = new Presentation();
  # 新しいVBAプロジェクトを作成
  $pres->setVbaProject(new VbaProject());
  # VBAプロジェクトに空のモジュールを追加
  $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
  # モジュールのソースコードを設定
  $module->setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");
  # <stdole> への参照を作成
  $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
  # Office への参照を作成
  $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
  # VBAプロジェクトに参照を追加
  $pres->getVbaProject()->getReferences()->add($stdoleReference);
  $pres->getVbaProject()->getReferences()->add($officeReference);
  $pres->save("data\\test.pptm", SaveFormat::Pptm);
```