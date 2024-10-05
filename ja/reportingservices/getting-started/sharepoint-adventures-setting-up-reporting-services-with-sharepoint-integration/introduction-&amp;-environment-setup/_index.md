---  
title: はじめに &amp; 環境設定  
type: docs  
weight: 10  
url: /reportingservices/introduction-&amp;-environment-setup/  
---  

{{% alert color="primary" %}}  

過去に、SharePointとの統合に関するAspose.Slides for Reporting Servicesの問い合わせがありました。本記事では、SharePoint 2010に焦点を当てます。すでにSharePoint Farm環境が設定されていることを前提としています。この記事で従う例は完全なSharePoint Cloudですが、手順はSharePoint Foundation Serverでも類似しています。進む前に、この作業の参考として使用できるいくつかの重要なドキュメントを見てみましょう：

- [Reporting Services と SharePoint 技術統合の概要](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))    
- [SharePoint 2010 統合のための Reporting Services の設定](https://docs.microsoft.com/en-us/previous-versions/sql/)  

{{% /alert %}}  
#### **環境設定**  
私たちが持つ設定は **4 台のサーバー** で構成されています。それには **ドメインコントローラー**、 **SQL サーバー**、 **SharePoint サーバー**、および **Reporting Services** 用のサーバーが含まれます。SharePoint と Reporting Services を同一のボックスに配置することも選択できます。