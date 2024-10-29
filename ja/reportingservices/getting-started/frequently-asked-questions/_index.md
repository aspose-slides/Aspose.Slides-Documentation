---
title: よくある質問
type: docs
weight: 110
url: /ja/reportingservices/frequently-asked-questions/
---

{{% alert color="primary" %}} 

このページでは、以下のよくある質問をまとめています：

- [対応ファイル形式](#Supported-File-Formats)。
- [Power BI Reporting Servicesのサポート](#Support-for-Power-BI-Reporting-services)。
- [インストール](#Installation)。
- [エクスポート設定](#Export-Configuration)。

{{% /alert %}} 
### **対応ファイル形式**
#### **Q: Aspose.Slides for Reporting Servicesを使用してレポートをどのフォーマットにエクスポートできますか？**
**A**: Aspose.Slides for Reporting Servicesを使用すると、レポートをPPT、PPS、PPTX、PPSX、XPS、またはRPLフォーマットにエクスポートできます。
### **Power BI Reporting Servicesのサポート**
#### **Q: Aspose.Slides for Reporting ServicesはPower BIをサポートしていますか？**
**A**: はい。Aspose.Slides for Reporting Servicesは、Power BIでページネートされたレポート（RDL）のエクスポートをサポートしています。
### **インストール**
#### **Q: インストールプログラムが起動しません。手動インストールでも望ましい結果が得られません。**
**A**: .NET Framework 3.5がシステムにインストールされていることを確認してください。
#### **Q: Aspose.Slides for Reporting Servicesのインストール後にエクスポートオプションが表示されません。**
**A**: rssrvpolicy.config内のCodeGroupが正しく機能しない場合、構成ファイルパーサーはグループの最後のセクションをスキップする可能性があります。そのため、Aspose.Slides for Reporting Servicesに関連するすべてのCodeGroupを、Aspose.Slides for Reporting ServicesのCodeGroupsを含むブロックのトップに移動してください。
#### **Q: ファイルまたはアセンブリAspose.Slides.ReportingServicesを読み込めませんでした（実行権限を取得できません \ HRESULT: 0x80131418の例外）。**
**A**: エラーコード（0x80131418）は、dllモジュールに十分な権限がないことを示しています。これは、安全機能が他のコンピュータから取得した.dllファイルへの完全なアクセスをブロックしたためかもしれません。この問題は、dllファイルのプロパティウィンドウを開き、「セキュリティ」パネルの「ブロック解除」ボタンをクリックすることで解決できます。
#### **Q: ライセンス'Aspose.Slides.Reporting.Services.lic'が見つかりません。**
**A**: ライセンスファイルはdllファイルの隣に配置するか、Program Files(x86)\Aspose\Slides\ディレクトリ内に置く必要があります。
### **エクスポート設定**
#### **Q: エクスポートされたレポートのハイパーリンクの色を変更するにはどうすればよいですか？**
**A**: rsreportserver.config内の各Aspose.Slides for Reporting Servicesレンダリング拡張機能には独自の設定があります。ハイパーリンクの色を変更するには、<HyperlinkColor>セクションに必要な値を設定してください。
#### **Q: エクスポートされたプレゼンテーションで、テーブルのテキストが縦に伸びています。**
**A**: これは、ドキュメントを読みやすくするために行われています。テーブル内のテキストをレポートに表示されるようにするには、rsreportserver.configの設定ファイルで必要なAspose.Slides for Reporting Services拡張機能を「通常」に設定してください。