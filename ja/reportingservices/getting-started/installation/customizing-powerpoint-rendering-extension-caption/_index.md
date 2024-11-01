---
title: PowerPointレンダリング拡張のキャプションをカスタマイズする
type: docs
weight: 60
url: /ja/reportingservices/customizing-powerpoint-rendering-extension-caption/
---

{{% alert color="primary" %}} 

この記事では、Aspose.Slides for Reporting Servicesのレンダリングオプションキャプションをカスタマイズする方法を示します。 

{{% /alert %}} 
## **例**
Aspose.Slides for Reporting Servicesをインストールすると、エクスポートオプションのドロップダウンメニューに4つの追加エクスポートオプションが追加されます:

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **キャプションテキストの変更方法**
これらの拡張のデフォルトのキャプションは、デフォルトの名前をオーバーライドすることによって変更できます。以下の手順では、「 **PPT – PowerPoint** **Presentation via** **Aspose.Slides** 」から「 **PowerPoint 97 – 2003 format(PPT)** 」にキャプションを変更する方法を示します。 

**ステップ 1:** 通常このディレクトリにある **rsreportserver.config** ファイルを見つけます: 

**OSルートドライブ\プログラムファイル\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**ステップ 2:** rsreportserver.configファイル内で以下の行を見つけます: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>



```

**ステップ 3:** 拡張パラメーターを以下のように置き換えます: 

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>



```

エクスポートオプションは次のように表示されます: 

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)