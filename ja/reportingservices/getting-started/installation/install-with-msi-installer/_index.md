---
title: MSI インストーラーでインストール
type: docs
weight: 20
url: /ja/reportingservices/install-with-msi-installer/
keywords:
  - MSI インストーラー
  - インストール
  - SQL Server Reporting Services
  - Power BI Report Server
  - Aspose.Slides for Reporting Services
description: "MSI インストーラーを使用して Aspose.Slides for Reporting Services をインストールします。インストーラーに必要なもの、各レポートサーバー インスタンスでの変更点、および結果の確認方法を説明します。"
---
## **インストール**

MSI インストーラーは Aspose.Slides for Reporting Services をインストールする最も簡単な方法です。.NET Framework 3.5 とレポート サーバー上の管理者権限が必要です。詳細は[System Requirements](/slides/ja/reportingservices/system-requirements/)をご覧ください。

1. MSI インストーラー（*Aspose.Slides for Reporting Services XX.XX*）を[download page](https://releases.aspose.com/slides/ja/reportingservices/)からダウンロードし、レポート サーバーにコピーします。
1. 管理者として実行します。.NET Framework 3.5 が不足している場合、インストーラーはメッセージで停止します。.NET Framework 3.5 の機能をインストールしてから再度実行してください。
1. ライセンス契約に同意します。
1. **Custom Setup** ページで、機能ツリーはインストーラーがマシン上で検出した各 SQL Server Reporting Services および Power BI Report Server インスタンスを一覧表示します。インスタンスを変更しないままにするには、そのアイコンをクリックし、**Entire feature will be unavailable** を選択します。Express エディションはレンダリング拡張機能をサポートしないため、Express インスタンスは選択しないでください。インストーラーは SQL Server 2016 以前の Express インスタンスを非表示にします。
1. **Next** を選択し、次に **Install** を選択します。
1. オプションの **Rpl Export** 機能は既定では選択されていません。これにより、レポートを RPL 形式で保存する隠し拡張機能が追加され、Aspose に問題レポートを送信する際に便利です。詳細は[Exporting Reports to RPL Format](/slides/ja/reportingservices/exporting-reports-to-rpl-format/)をご覧ください。

## **インストーラーが行う変更**

インストーラーはファイルを *Aspose\Aspose.Slides for Reporting Services* に、Program Files フォルダー（64 ビット Windows の場合は *Program Files (x86)*）の下に格納します。これはインストーラーが 32 ビット パッケージであるためです。その後、選択された各インスタンスについて、以下を実行します:

- *Aspose.Slides.ReportingServices.dll* をインスタンスの *ReportServer\bin* フォルダーにコピーします — SQL Server 2005 用のビルド、または SQL Server 2008 以降および Power BI Report Server 用のビルドです。
- `<Render>` 要素（*rsreportserver.config*）に、6 つのレンダリング拡張機能 — ASPPT、ASPPS、ASPPTX、ASPPSX、ASXPSS、ASODP — を追加します。
- *rssrvpolicy.config* に、アセンブリに完全信頼を付与するコード グループを追加します。
- 変更した各構成ファイルのコピーを、ファイル名に *.bak* を付加して保存します。

[Install Manually](/slides/ja/reportingservices/install-manually/) では、これらの変更をステップバイステップで示しています。

インスタンスを構成できない場合、インストーラーはメッセージでインスタンス名を示し、インストール フォルダーの *rserrors&lt;date&gt;.log* に詳細を書き込みます。そのインスタンスに対しては、拡張機能を手動でインストールしてください。

## **インストールの確認**

Web ポータル（SQL Server 2014 以前では Report Manager）でページ分割レポートを開き、**Export** リストを開きます。現在、以下の形式が含まれています:

- PPT - Aspose.Slides による PowerPoint プレゼンテーション
- PPS - Aspose.Slides による PowerPoint スライドショー
- PPTX - Aspose.Slides による PowerPoint 2007 プレゼンテーション
- PPSX - Aspose.Slides による PowerPoint 2007 スライドショー
- ODP - Aspose.Slides による OpenDocument プレゼンテーション
- XPS - Aspose.Slides による

ライセンスがない場合、エクスポートされたファイルには評価版の透かしが付加されます。詳細は[Licensing](/slides/ja/reportingservices/license-aspose-slides-for-reporting-services/)をご覧ください。

## **手動でインストールする場合**

以下の場合は、拡張機能を[手動で](/slides/ja/reportingservices/install-manually/)インストールしてください:

- インストーラーがインスタンスを構成できない場合（例：サーバーのセキュリティ設定が原因）；
- アップグレード後、古いバージョンをアンインストールして新しいインストーラーを実行する代わりに、アセンブリだけを置き換えたい場合。

製品をアンインストールすると、各インスタンスからアセンブリと構成エントリが削除されます。