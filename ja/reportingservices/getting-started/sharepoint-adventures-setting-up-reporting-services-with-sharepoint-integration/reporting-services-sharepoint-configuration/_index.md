---
title: Reporting Services SharePoint 構成
type: docs
weight: 50
url: /reportingservices/reporting-services-sharepoint-configuration/
---

{{% alert color="primary" %}} 

RS サーバーに SharePoint がインストールされ、構成が完了し、Reporting Services Configuration Manager を通じて RS がセットアップされたので、Central Admin 内の構成に進むことができます。RS 2008 R2 はこのプロセスを本当に簡素化しました。作業を行うためには3ステップのプロセスが必要でしたが、今では1ステップだけです。

Central Administrator Web サイトに移動し、General Application Settings に入ります。画面の下部に Reporting Services が表示されます。

{{% /alert %}} 

![todo:image_alt_text](reporting-services-sharepoint-configuration_1.png)

**図 17**: SharePoint 構成 

{{% alert color="primary" %}} 

「 **Reporting Services Integration** 」をクリックします。

{{% /alert %}} 
## **Web サービス URL**
Reporting Services Configuration Manager で見つけた Report Server の URL を提供します。
## **認証モード**
認証モードも選択します。以下の MSDN リンクではこれらの詳細が説明されています。
[SharePoint 統合モードの Reporting Services のセキュリティ概要](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb283324(v=sql.105)) 

要するに、サイトが **Claims Authentication** を使用している場合、ここで選択するものにかかわらず、常に Trusted Authentication を使用します。Windows 認証を渡したい場合は、Windows Authentication を選択してください。Trusted Authentication では、SPUser トークンを渡し、Windows 認証には依存しません。

Classic Mode サイトを NTLM 用に構成し、RS が NTLM 用に設定されている場合も、Trusted Authentication を使用することをお勧めします。Windows Authentication を使用し、それをデータソースに渡すには Kerberos が必要です。

![todo:image_alt_text](reporting-services-sharepoint-configuration_2.png)

**図 18**: Reporting Services Integration 認証情報の設定
## **機能の有効化**
これにより、すべてのサイトコレクションで Reporting Services を有効化するオプションが得られます。また、どのサイトで有効化するかを選択することもできます。これは、どのサイトが Reporting Services を使用できるかを示します。
完了すると、次の図が表示されるはずです。

![todo:image_alt_text](reporting-services-sharepoint-configuration_3.png)

**図 19**: SharePoint 環境との Reporting Services の統合に成功 

図 14 で示された Report Server URL に戻ると、次の図に似たものが表示されるはずです。

![todo:image_alt_text](reporting-services-sharepoint-configuration_4.png)

**図 20**: SharePoint 環境との Reporting Services の検証に成功 

{{% alert color="primary" %}} 

SharePoint サイトが SSL 用に構成されている場合、このリストには表示されません。これは既知の問題であり、問題があることを意味するものではありません。レポートは引き続き機能するはずです。

{{% /alert %}} 

これで、SharePoint 2010 で Reporting Services を使用する準備が整いました。前のバージョンと同様に、「サイトコレクション機能」で Reporting Services Integration を構成すると有効化される機能があります。また、インストールにより、サイトに追加するための 3 つのコンテンツタイプが追加されました。図 21 では、ドキュメントライブラリに追加された 2 つのコンテンツタイプを使用してカスタムレポートを作成する様子が示されています。

![todo:image_alt_text](reporting-services-sharepoint-configuration_5.png)

**図 21**: Report Builder 

「 **Report Builder** 」は、サーバーにダウンロードする必要がある ActiveX です。図 22 に示されています。

![todo:image_alt_text](reporting-services-sharepoint-configuration_6.png)

**図 22**: Report Builder のダウンロードとインストール 

ダウンロードが完了したら、**“Report Builder”** を実行します。これで、最初のレポートを設計する準備が整いました。図 23 に示されています。

![todo:image_alt_text](reporting-services-sharepoint-configuration_7.png)

**図 23**: Report Builder 新しいレポート作成ウィザード 

レポートを作成したら、SharePoint 2010 のレポートを置くために作成したドキュメントライブラリに保存できます。

もう1つのコンテンツタイプは、データソースとして共有接続を作成し、SharePoint のドキュメントライブラリに保存するために使用されます。ドキュメントライブラリを作成し、このコンテンツタイプを追加すると、レポートのデータソースを変更するための接続を利用可能にすることができます。

![todo:image_alt_text](reporting-services-sharepoint-configuration_8.png)

**図 24**: Report Server へのレポートの成功したエクスポート