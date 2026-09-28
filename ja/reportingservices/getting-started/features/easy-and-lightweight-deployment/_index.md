---
title: 簡単で軽量なデプロイ
type: docs
weight: 50
url: /ja/reportingservices/easy-and-lightweight-deployment/
description: "Aspose.Slides for Reporting Services がどのようにデプロイされるかを学びます。レポートサーバーの bin フォルダーに 1 つのアセンブリが配置され、レポートサーバーの構成に登録されます。"
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for Reporting Services は、Microsoft SQL Server Reporting Services および Power BI Report Server 用のレンダリング拡張機能です。  
Aspose.Slides for Reporting Services は、サポートされているレポート サーバー（32 ビットまたは 64 ビット）上で実行されるコンピューターにインストールできる単一の MSI インストーラーとして提供されます。システム要件は [System Requirements](/slides/ja/reportingservices/system-requirements/) を参照してください。

Aspose.Slides for Reporting Services は、1 つの .NET アセンブリ *Aspose.Slides* *.ReportingServices.dll* だけで構成されており、完全に C# で記述され、CLS に準拠し、安全なマネージド コードのみを含むため、手動での展開および管理も容易です。

{{% /alert %}}

ZIP ダウンロードには、レポート サーバー用の Aspose.Slides.ReportingServices.dll の 2 つのビルドが含まれています。

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – Microsoft SQL Server 2005 および .NET Framework 2.0 用にビルドされました (x86 および x64 用)
- Bin\Universal\Aspose.Slides.ReportingServices.dll – Microsoft SQL Server 2008 以降、Power BI Report Server、.NET Framework 2.0 用にビルドされました (x86 および x64 用)

MSI インストーラーは同じ 2 つのビルドをインストールし、各レポート サーバー インスタンスに適したものを選択します。[Install Manually](/slides/ja/reportingservices/install-manually/) では ZIP ダウンロード内のすべてのファイルが一覧表示されています。

インストール時に、Aspose.Slides.ReportingServices.dll は ReportServer\bin ディレクトリにコピーされ、構成ファイルが更新されて Reporting Services が新しいレンダリング拡張機能を認識できるようになります。これらの手順は Aspose.Slides for Reporting Services インストーラーによって実行されますが、本ドキュメントの後述にあるように手動で実行することも可能です。

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**図**: Aspose.Slides.ReportingServices.dll が **ReportServer\bin** ディレクトリにコピーされます。