---
title: Aspose.Slides for SharePointライセンスのアンインストール
type: docs
weight: 20
url: /sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---

ライセンスをアンインストールするには、以下の手順をサーバーコンソールから実行してください。

1. ファームからライセンスソリューションを撤回します：

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. 撤回を即座に完了させるために、管理者タイマージョブを実行します：

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. 撤回が完了するのを待ちます。**中央管理**の下で撤回が完了したかどうかを確認するには、**中央管理**、次に**操作**、そして**ソリューション管理**を使用できます。
4. SharePointソリューションストアからソリューションを削除します：

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```