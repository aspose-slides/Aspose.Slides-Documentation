---
title: インストールの前提条件
type: docs
weight: 20
url: /ja/reportingservices/installation-prerequisites/
---

{{% alert color="primary" %}} 

インストールを進める前に、以下の前提条件を満たす必要があります。 

{{% /alert %}} 
## **SharePoint用レポーティングサービスアドイン**
**SharePoint用レポーティングサービスアドイン**は、統合を正しく機能させるための主要なコンポーネントの一つです。このアドインは、SharePointファーム内の**Webフロントエンド(WFE)**および中央管理サーバーにインストールする必要があります。SQL 2008 R2とSharePoint 2010を使用する際の新しい変更の一つは、2008 R2アドインがSharePointのインストールの前提条件になったことです。これは、SharePointをインストールするときにRSアドインが配置されることを意味します。以下の図に示されているように、これによりSP 2007とRS 2008をインストールする際に見られた多くの問題を回避することができます。 

![todo:image_alt_text](installation-prerequisites_1.png)


**図1**: SharePoint用レポーティングサービスアドイン 
## **SharePoint認証**
RS統合の部分に入る前に重要なのは、SharePointファーム内で**サイト**をどのように設定するかです。具体的には、サイトの認証をどのように構成するか、**Classic**または**Claims**のいずれかになるかです。この選択は最初に重要です。一度設定すると、このオプションを変更できないと考えています。変更できる場合でも、それは簡単なプロセスではありません。 

{{% alert color="primary" %}} 

レポーティングサービス2008 R2はClaimsに対応していません 

{{% /alert %}} 

SharePointサイトを**Claims**を使用するように選択した場合でも、レポーティングサービス自体はClaimsに対応していません。これは、レポーティングサービスの認証の動作に影響を与えます。では、レポーティングサービスの観点からの違いは何でしょうか？それは、ユーザーの資格情報をデータソースに転送したいかどうかにかかっています。 

***Classic***   - Kerberosを使用し、ユーザーの資格情報をバックエンドデータソースに転送できます（そのためにはKerberosを使用する必要があります）。 

***Claims*** ** - Claimsトークンが使用され、Windowsトークンは使用されません。このシナリオでは、RSは常に信頼された認証を使用し、SPUserトークンにのみアクセスします。資格情報をデータソース内に保存する必要があります。 

今はRSのセットアップに焦点を当てたいと思います。この時点で、SharePointはSharePointボックスにインストールされ、**ポート80**で**Classic Auth Site**が設定されています。さらに、RSサーバーには**レポーティングサービスをインストールしたばかり**です。それだけです。