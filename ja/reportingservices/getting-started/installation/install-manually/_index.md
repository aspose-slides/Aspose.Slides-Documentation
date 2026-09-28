---
title: 手動インストール
type: docs
weight: 30
url: /ja/reportingservices/install-manually/
keywords:
- 手動インストール
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "DLL のみが含まれる ZIP パッケージから Aspose.Slides for Reporting Services を手動でインストールします：コピーするアセンブリと rsreportserver.config および rssrvpolicy.config に追加する内容。"
---
## **概要**

MSI インストーラを使用せず、ZIP パッケージ *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* から Aspose.Slides for Reporting Services をインストールするには、以下の手順に従ってください。ダウンロードページは[ダウンロードページ](https://releases.aspose.com/slides/ja/reportingservices/)。これらは[MSI インストーラ](/slides/ja/reportingservices/install-with-msi-installer/)と同じ拡張機能を登録します。各レポートサーバー インスタンスごとに繰り返してください。

開始する前に、[システム要件](/slides/ja/reportingservices/system-requirements/)を確認してください。レポートサーバー上でローカル管理者権限が必要です。

## **アセンブリの選択**

ZIP パッケージには複数のビルドが含まれています。*Aspose.Slides.ReportingServices.dll* を 1 つだけレポートサーバーにコピーしてください。

| ZIP パッケージ内のファイル | 用途 |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 以降の Reporting Services および Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | レポートサーバー用ではありません：ReportViewer 2010 または 2012 コントロールからエクスポートするアプリケーションです。詳細は[ReportViewer 2010 と 2012 での Aspose.Slides の使用](/slides/ja/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | オプション：問題レポート用に RPL 形式でレポートを保存します。詳細は[RPL 形式へのレポートのエクスポート](/slides/ja/reportingservices/exporting-reports-to-rpl-format/) |

## **レポートサーバーフォルダーを探す**

以下の手順は、*ReportServer* フォルダー（*rsreportserver.config* と *rssrvpolicy.config* が格納されている）を対象としています。デフォルト インストールでは次の場所です。

| レポートサーバー | デフォルト *ReportServer* フォルダー |
| :- | :- |
| SQL Server 2017 以降の Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 以前の Reporting Services | `C:\Program Files\Microsoft SQL Server\<instance folder>\Reporting Services\ReportServer`、ここで `<instance folder>` は例として SQL Server 2016 の場合 `MSRS13.MSSQLSERVER`、SQL Server 2005 の場合 `MSSQL.x` です |

その他の場所については、Microsoft の[RsReportServer.config 設定ファイル](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file)記事をご覧ください。

## **拡張機能のインストール**

1. 選択したアセンブリを *ReportServer* フォルダーの *bin* サブフォルダーにコピーします。

   コピーしたファイルに明示的に割り当てられた NTFS 権限が残っていると、アセンブリのロード時にレポートサーバーがアクセス拒否され、新しいエクスポート形式が表示されなくなります。ファイルを右クリックし **プロパティ** を選択、**セキュリティ** タブで明示的に設定された権限をすべて削除し、継承された権限のみを残します。**全般** タブに **ブロック解除** オプションが表示されている場合は、それを選択してください。

2. *rsreportserver.config* のコピーを保存し、テキスト エディタで開きます。`<Render>` 要素内に以下のエントリを追加します：

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   各エントリは 1 つのエクスポート形式を登録します。`Name` はレンダリング拡張機能間で一意である必要があります。MSI インストーラは同じ 6 つの名前とタイプを登録します。エクスポート一覧に不要な形式がある場合は、そのエントリを省略してください。

3. *rssrvpolicy.config* のコピーを保存し、テキスト エディタで開きます。`Description` が "This code group grants MyComputer code Execution permission." であるコード グループを探し、次のコード グループを最後の子として追加します：

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` は Aspose.Slides.ReportingServices アセンブリの公開鍵です。1 行に収めてください。

4. 両方のファイルを保存します。レポートサーバーはファイルが保存されるたびに設定ファイルを再読み込みします。XML が不正な場合、サーバーはそのファイルを無視するか起動に失敗するため、問題が発生したら保存したコピーを復元してください。

## **インストールの確認**

Web ポータル（SQL Server 2014 以前は Report Manager）でページングされたレポートを開き、**エクスポート** リストを表示します。以下の形式が含まれるようになります。

- PPT - Aspose.Slides による PowerPoint プレゼンテーション
- PPS - Aspose.Slides による PowerPoint スライドショー
- PPTX - Aspose.Slides による PowerPoint 2007 プレゼンテーション
- PPSX - Aspose.Slides による PowerPoint 2007 スライドショー
- ODP - Aspose.Slides による OpenDocument プレゼンテーション
- XPS - Aspose.Slides による XPS

いずれかを選択してレポートをエクスポートします。ファイルはその形式に関連付けられたアプリケーションで開きます。

![Aspose.Slides for Reporting Services によって PowerPoint にエクスポートされたレポート](install-manually_2.png)

形式が表示されない場合は、コピーしたアセンブリの NTFS 権限を確認してください。ライセンスがない場合、エクスポートされたファイルには評価版の透かしが付加されます。詳細は[ライセンス](/slides/ja/reportingservices/license-aspose-slides-for-reporting-services/)をご覧ください。