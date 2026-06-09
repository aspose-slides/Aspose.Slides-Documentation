---
title: RPL formatına raporları dışa aktarma
type: docs
weight: 110
url: /tr/reportingservices/exporting-reports-to-rpl-format/
---

{{% alert color="primary" %}} 
Aspose.Slides, raporları işlemek için RPL (Report Processing Language) formatını kullanır. Bu sayfa, raporların RPL formatına nasıl dışa aktarılacağını gösterir. 
{{% /alert %}} 

Birçok senaryoda, müşteriler sorunlu raporları çözüm için Aspose personeliyle paylaşmak zorunda kalırlar. Paylaşılan raporlar RDL biçimindeyse, sorunu yeniden oluşturabilmemiz için veri kümesi veya şema da paylaşılır. Bazen, RDL raporu ve veri kümesinin paylaşılması sorunu tamamen çözmek için yeterli olmayabilir. Bu gibi durumlarda, raporları RPL formatında dışa aktarmanızı ve RPL dosyasını bizimle paylaşmanızı öneririz. RPL dosyası, içinde kullanılan veri kümesini de içerir. Bu sayede RPL’ye dışa aktarmak daha kolay olur ve dosya anında bizimle paylaşılabilir.

Aşağıdaki adımları izleyin:

1. Aspose.ReportingServices.Debug.Rpl.dll dosyasını Reporting Services bin dizinine (genellikle c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin) kopyalayın.

{{% alert color="primary" %}} 
Aspose.ReportingServices.Debug.Rpl.dll, Aspose.Slides for Reporting Services'ın en son sürümlerinde bulunur ve [Releases page](https://releases.aspose.com/slides/tr/reportingservices/) üzerinden indirilebilir. 
{{% /alert %}} 

2. Bu uzantıyı **<Render>** etiketi içine **rsreportserver.config** dosyasına ekleyin (genellikle c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config)

``` xml



//Bu etiketi <Render> öğesine ekleyin 



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. Yol öğesini değiştirerek elde edilen RPL dosyalarının yolunu belirtin.

4. Aspose.ReportingServices.Debug.Rpl.dll dosyasına aşağıdaki şekilde çalıştırma izni verin: C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config dosyasını açın ve ikinci dış **<CodeGroup>** öğesinin sonuna (bu **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">** olmalıdır) aşağıdaki satırı ekleyin:

``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--Buradan başlayın.-->

				<CodeGroup class="UnionCodeGroup"
					version="1"
					PermissionSetName="FullTrust"
					Name="Aspose.Rpl_Debug_for_Reporting_Services"
					Description="Code group for my Aspose.Rpl.Debug rendering extension">
			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />
				</CodeGroup>

    <!--Buradan sonlandırın.-->

  </CodeGroup>

</CodeGroup>


```

5. Reporting Services’ı yeniden başlatın. Dışa Aktarma menüsünde Aspose.Rpl seçeneğini bulmalısınız.

“Rpl export” seçeneği dışa aktarma panelinde görünmelidir. Raporu RPL’ye dışa aktarın ve RPL dosyasını paylaşın.