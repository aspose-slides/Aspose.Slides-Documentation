---  
title: Aspose.Slides.ReportingService をサーバーにインストールせずに Powerpoint にレポートをエクスポートする   
type: docs  
weight: 120  
url: /reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/  
---  
  
{{% alert color="primary" %}}  
  
Aspose.Slides for Reporting Service は、サーバーにインストールせずに使用できます。このアプローチは、アプリケーションに Powerpoint へのエクスポートを統合する必要があるが、サービスへのアクセスが制限されている場合に適しています。  
  
{{% /alert %}} {{% alert color="primary" %}}  
  
このアプローチを示す Visual Studio ソリューションは [こちら](attachments/10289165/10453062.zip) で見つけることができます。  
  
{{% /alert %}}  
  
レンダリングプロセスは2つの部分から構成されます：  
  
1. Reporting Service Web Service を使用して RPL にレポートをレンダリングします。Reporting Service Web Service の詳細については [こちら](http://technet.microsoft.com/en-us/library/ms152787.aspx) を参照してください。  
1. ReportViewer 用の Aspose.Slides for Reporting Service を使用して RPL を Powerpoint にレンダリングします。アセンブリは {Aspose.Slides for Reporting Services home directory}\bin\RV2010 にあります  
## **PowerPoint へのエクスポートを実装する方法：**  
1) Web サービスプロキシを作成します (詳細については [こちら](http://technet.microsoft.com/en-us/library/ms155134.aspx) を参照) 并びにそれをソリューションに追加します。  
  
2) ReportViewer 2010 用の Aspose.Slides.ReportingServices.dll への参照を追加します。  
  
3) このクラスを使用して Web サービスプロキシと Aspose.Slides for Reporting Service を統合します  
  
``` xml  
  
 class PowerpointRenderer  
  
{  
  
/// <summary>  
  
/// クライアントが要求している XML Web サービスの基本 URL を取得または設定します。  
  
/// </summary>  
  
/// <value>  
  
/// クライアントが要求している XML Web サービスの基本 URL。デフォルトは System.String.Empty です。  
  
/// </value>  
  
public string ReportingServiceUrl { get; set; }  
  
  
/// <summary>  
  
/// Reporting Service のユーザー名を取得または設定します。  
  
/// </summary>  
  
/// <value>  
  
/// ユーザー名。  
  
/// </value>  
  
public string Username { get; set; }  
  
/// <summary>  
  
/// Reporting Service のパスワードを取得または設定します。  
  
/// </summary>  
  
/// <value>  
  
/// パスワード。  
  
/// </value>  
  
public string Password { get; set; }  
  
/// <summary>  
  
/// 指定されたレポートをファイルにレンダリングします。  
  
/// </summary>  
  
/// <param name="outputFileName">出力ファイルの名前。</param>  
  
/// <param name="reportPath">レポートパス。</param>  
  
/// <param name="format">出力プレゼンテーションフォーマット。</param>  
  
public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)  
  
{  
  
using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))  
  
{  
  
Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();  
  
//レンダリングプロセスの開始  
  
//ここでは、PPTフォーマットでエクスポートすることを選択し、outputStream を提供します。  
  
renderer.StartRendering(format, false);  
  
int page = 1;  
  
//このサイクルはレポートのすべてのページを繰り返します。  
  
while (true)  
  
{  
  
using (MemoryStream rplStream = CreateRplStream(page, reportPath))  
  
{  
  
//rplStream が空であれば、レポートの終わりに達したことになります。  
  
if (rplStream.Length == 0)  
  
break;  
  
//レポートページをスライドとしてドキュメントに追加します。  
  
renderer.RenderPage(rplStream);  
  
}  
  
page++;  
  
}  
  
//finish メソッドを呼び出して新しく作成したプレゼンテーションを出力ストリームにフラッシュします。  
  
renderer.FinishRendering(pptSteam);  
  
}  
  
}  
  
private MemoryStream CreateRplStream(int page, string reportPath)  
  
{  
  
ReportExecutionService _executionService = new ReportExecutionService();  
  
_executionService.Url = ReportingServiceUrl + "/ReportExecution2005.asmx";  
  
_executionService.Credentials = new System.Net.NetworkCredential(Username, Password, string.Empty);  
  
string extension;  
  
Warning[] warnings;  
  
string[] streamIds;  
  
string mimeType;  
  
string encoding;  
  
var executionInfo = _executionService.LoadReport(reportPath, null);  
  
string deviceInfo = String.Format(  
  
@"<DeviceInfo>  
  
<StartPage>{0}</StartPage>  
  
<EndPage>{0}</EndPage>  
  
<SecondaryStreams>Embedded</SecondaryStreams>  
  
</DeviceInfo>", page);  
  
byte[] result = _executionService.Render("RPL", deviceInfo, out extension, out mimeType, out encoding, out warnings, out streamIds);  
  
return new MemoryStream(result);  
  
}  
  
```  
  
4) これで、次のコードを通じてレポートをエクスポートできます：  
  
``` xml  
  
 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();  
  
powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";  
  
powerpointRenderer.Username = "Username";  
  
powerpointRenderer.Password = "password";  
  
powerpointRenderer.Render("test.ppt", "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);  
  
```  
  
{{% alert color="primary" %}}  
  
ここでのエクスポートプロセスは、Word や Excel と似たソフト ページブレークを使用しているため、結果は標準アプローチを使用してエクスポートされたプレゼンテーションと異なる場合があります。  
  
{{% /alert %}}