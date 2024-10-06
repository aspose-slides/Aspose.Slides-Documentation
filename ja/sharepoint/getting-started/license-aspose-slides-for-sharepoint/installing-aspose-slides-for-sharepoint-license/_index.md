---
title: Aspose.Slides for SharePointライセンスのインストール
type: docs
weight: 10
url: /ja/sharepoint/installing-aspose-slides-for-sharepoint-license/
---

{{% alert color="primary" %}} 

評価に満足したら、[ライセンスを購入](https://purchase.aspose.com/buy)できます。購入前に、ライセンスサブスクリプションの条件を理解し、同意していることを確認してください。注文が支払われると、ライセンスがメールで送信されます。

ライセンスは、通常のSharePointソリューションパッケージを含むZIPアーカイブです。アーカイブには次のものが含まれています：

- Aspose.Slides.SharePoint.License.wsp – SharePointソリューションパッケージファイル。このライセンスは、サーバーファーム全体での展開と撤回を簡単にするためにSharePointソリューションとしてパッケージ化されています。
- readme.txt – ライセンスインストール手順。

{{% /alert %}} 
## **ライセンスの展開**
ライセンスのインストールは、**stsadm.exe**を介してサーバーコンソールから行われます。

{{% alert color="primary" %}} 

以下のセクションでは、明確性のためにパスは省略されています。

{{% /alert %}} 

Aspose.Slides for SharePointライセンスを展開するための手順は次のとおりです：

1. stsadmを実行してソリューションをSharePointソリューションストアに追加します：

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. ソリューションをファーム内のすべてのサーバーに展開します：

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. 展開を即座に完了させるために管理タイマージョブを実行します：

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

Windows SharePoint Services Administrationサービスが実行されていない場合、展開ステップを実行すると警告が表示されます。**stsadm.exe**はこのサービスとWindows SharePoint Timer Serviceに依存しており、ファーム全体でソリューションデータを複製します。これらのサービスがサーバーファームで実行されていない場合、各サーバーでライセンスを展開する必要があるかもしれません。

{{% /alert %}} 
## **ライセンスのテスト**
ライセンスが正しくインストールされたかを確認するために、任意のドキュメントを新しい形式に変換します。ドキュメントに評価用の透かしが表示されていない場合、ライセンスは正常にアクティブ化されています。