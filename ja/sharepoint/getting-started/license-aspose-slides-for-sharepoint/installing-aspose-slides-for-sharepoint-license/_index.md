---
title: Aspose.Slides for SharePoint ライセンスのインストール
type: docs
weight: 10
url: /ja/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "SharePoint ファームに Aspose.Slides for SharePoint のライセンスをインストールします。ライセンス ソリューションをソリューション ストアに追加し、展開し、変換されたファイルに評価用透かしが残っていないことを確認します。"
---
{{% alert color="info" title="Note" %}}

評価に満足したら、[ライセンスを購入](https://purchase.aspose.com/pricing/slides/ja/sharepoint/)できます。購入前に、ライセンスのサブスクリプション条件を理解し、同意していることをご確認ください。注文が支払われると、ライセンスはメールで送信されます。

ライセンスは通常の SharePoint ソリューション パッケージを含む ZIP アーカイブです。アーカイブには以下が含まれます:

- Aspose.Slides.SharePoint.License.wsp – SharePoint ソリューション パッケージ ファイルです。ライセンスは SharePoint ソリューションとしてパッケージ化され、サーバーファーム全体への展開および撤回が容易になります。
- readme.txt – ライセンス インストール手順です。

{{% /alert %}}

## **ライセンスの展開**

ライセンスのインストールはサーバーコンソールから **stsadm.exe** を使用して実行されます。

{{% alert color="info" title="Note" %}}

以下のセクションでは、明確にするためにパスは省略しています。

{{% /alert %}}

Aspose.Slides for SharePoint ライセンスを展開するには、次の手順を実行してください。

1. stsadm を実行してソリューションを SharePoint ソリューション ストアに追加します:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. ファーム内のすべてのサーバーにソリューションを展開します:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. 管理タイマージョブを実行して、展開をすぐに完了させます:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

`addsolution` 操作は `-filename` にソリューション ファイルのパスを指定します。`deploysolution` 操作は `-name` にソリューション ストアに既に存在するソリューション名を指定します。

{{% alert color="info" title="Note" %}}

展開手順を実行する際に SharePoint Administration サービスが実行されていないと警告が表示されます。**stsadm.exe** はこのサービスおよび SharePoint Timer サービスに依存しており、ファーム全体にソリューション データをレプリケートします。これらのサービスがサーバーファームで実行されていない場合、各サーバーにライセンスを展開する必要があります。

{{% /alert %}}

{{% alert color="info" title="Note" %}}

SharePoint 2010 以降では、SharePoint Management Shell のコマンドレット `Add-SPSolution`、`Install-SPSolution`、`Start-SPAdminJob` がそれぞれ `addsolution`、`deploysolution`、`execadmsvcjobs` 操作に対応します。詳細は [Stsadm to Microsoft PowerShell mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping) を参照してください。

{{% /alert %}}

## **ライセンスのテスト**

ライセンスが正しくインストールされたかテストするには、任意のプレゼンテーションを新しい形式に変換します。変換後のファイルに評価用透かしが表示されなければ、ライセンスは有効です。