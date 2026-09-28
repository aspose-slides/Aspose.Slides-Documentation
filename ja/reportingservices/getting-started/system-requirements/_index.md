---
title: システム要件
type: docs
weight: 15
url: /ja/reportingservices/system-requirements/
keywords:
- システム要件
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "インストール前に、Aspose.Slides for Reporting Services が必要とするレポートサーバー、エディション、.NET Framework のバージョンを確認してください。"
---
## **概要**

Aspose.Slides for Reporting Services はレポートサーバー内でレンダリング拡張機能として実行されます。このページでは、[install](/slides/ja/reportingservices/installing-aspose-slides-for-reporting-services/) 前にレポートサーバーマシンに必要なものを一覧します。Microsoft PowerPoint および Microsoft Office は必要ありません。

## **対応レポートサーバー**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 および 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server（ページング (RDL) レポート用）

32 ビットと 64 ビットのレポートサーバーの両方をサポートしています。SQL Server 2005 は独自のビルドを使用し、以降のバージョンおよび Power BI Report Server は同じビルドを使用します。[Install Manually](/slides/ja/reportingservices/install-manually/) ではコピーすべきファイルが示されています。

このリストにないレポートサーバー バージョンを使用している場合は、デプロイ前に[free support forum](https://forum.aspose.com/c/slides/11)で質問してください。

## **レポートサーバーエディション**

SQL Server 2016 Reporting Services 以降および Power BI Report Server では、Enterprise、Standard、Developer、Evaluation エディションでレンダリング拡張機能がサポートされています。Web と Express エディションはサポート対象外です。エディション別のサポート機能については[Reporting Services features supported by editions](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server)を参照してください。MSI インストーラは SQL Server 2016 以前の Express エディションのインスタンスをスキップします。

## **.NET Framework**

レポートサーバーマシンに .NET Framework 3.5 がインストールされている必要があります。拡張機能のアセンブリは .NET Framework 2.0 ランタイム向けにビルドされており、.NET Framework 3.5 が不足している場合、MSI インストーラはメッセージを表示して停止します。Windows Server では「Add Roles and Features Wizard」で**.NET Framework 3.5 Features**を追加してください。詳細は[Install .NET Framework 3.5 on Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows)を参照してください。

## **権限**

拡張機能のインストールはレポートサーバーフォルダーのファイルを変更するため、両方のインストール方法でローカル管理者権限が必要です。管理者権限なしで MSI インストーラを起動すると、管理者権限で再起動するオプションが表示されます。

## **FAQ**

**レポートサーバーに Microsoft PowerPoint は必要ですか？**

いいえ。拡張機能はプレゼンテーションを自ら作成するため、PowerPoint も Microsoft Office もインストールする必要はありません。

**Express エディションに拡張機能をインストールできますか？**

いいえ。Express エディションはレンダリング拡張機能をサポートしていません。MSI インストーラは SQL Server 2016 以前の Express インスタンスを非表示にします。以降のバージョンでは、Express インスタンスを選択しないでください。

**拡張機能がエクスポートリストに追加する形式は何ですか？**

PPT、PPS、PPTX、PPSX、ODP、XPS です。詳しくは[Supported File Formats](/slides/ja/reportingservices/supported-file-formats/)を参照してください。