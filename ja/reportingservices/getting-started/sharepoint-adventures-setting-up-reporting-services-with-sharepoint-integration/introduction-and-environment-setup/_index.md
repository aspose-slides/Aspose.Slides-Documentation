---
title: 導入と環境設定
type: docs
weight: 10
url: /ja/reportingservices/introduction-and-environment-setup/
---

{{% alert color="primary" %}} 

ASP.NETのSharePointとの統合に関するAspose.Slidesについて過去にいくつかの問い合わせがありました。本記事ではSharePoint 2010に焦点を当てます。すでにSharePointファームの環境が設定されていることを前提としています。この記事でフォローする例は完全なSharePointクラウドですが、SharePoint Foundation Serverでも手順は類似しています。始める前に、これを行う際に参照として使用できるいくつかの重要なドキュメントを見てみましょう: 

- [Reporting Services と SharePoint 技術統合の概要](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))  
- [SharePoint 2010 統合のための Reporting Services の設定](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **環境設定**
私たちが持つ設定は **4つのサーバー**で構成されています。それには **ドメインコントローラー**、**SQLサーバー**、**SharePointサーバー**、および **Reporting Services**用のサーバーが含まれます。同じボックスにSharePointとReporting Servicesを配置することもできます。