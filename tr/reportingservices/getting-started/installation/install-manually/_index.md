---
title: Manuel Kurulum
type: docs
weight: 30
url: /tr/reportingservices/install-manually/
keywords:
- manuel kurulum
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Raporlama Servisleri
- Power BI Rapor Sunucusu
- Aspose.Slides for Reporting Services
description: "Aspose.Slides for Reporting Services'i DLL yalnızca ZIP paketinden elle kurun: hangi derlemenin kopyalanacağı ve rsreportserver.config ile rssrvpolicy.config dosyalarına ne ekleneceği."
---
## **Genel Bakış**

MSI yükleyicisi olmadan Aspose.Slides for Reporting Services'i, *Aspose.Slides for Reporting Services XX.XX (Sadece DLL'ler)* ZIP paketinden, [indirme sayfası](https://releases.aspose.com/slides/reportingservices/) üzerinden adımları izleyerek kurun. Bu adımlar, [MSI yükleyicisi](/slides/tr/reportingservices/install-with-msi-installer/) ile aynı uzantıları kaydeder. Her rapor sunucusu örneği için bu adımları tekrarlayın.

Başlamadan önce, [sistem gereksinimlerini](/slides/tr/reportingservices/system-requirements/) kontrol edin. Rapor sunucusunda yerel yönetici haklarına ihtiyacınız var.

## **Derlemeyi Seçin**

ZIP paketi birden fazla derleme içerir. Raport sunucusuna **tek bir** *Aspose.Slides.ReportingServices.dll* kopyalayın:

| ZIP paketindeki dosya | Ne için kullanılacağı |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 ve sonraki Reporting Services sürümleri ile Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | Rapor sunucusu için değil: ReportViewer 2010 veya 2012 denetiminden dışa aktaran uygulamalar, bkz. [Aspose.Slides'ı ReportViewer 2010 ve 2012 ile Kullanma](/slides/tr/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | İsteğe bağlı: sorun raporları için RPL formatında rapor kaydeder, bkz. [Raporları RPL Formatına Dışa Aktarma](/slides/tr/reportingservices/exporting-reports-to-rpl-format/) |

## **Rapor Sunucusu Klasörünü Bulun**

Aşağıdaki adımlar, *ReportServer* klasörüne ( *rsreportserver.config* ve *rssrvpolicy.config* dosyalarını içerir) atıfta bulunur. Varsayılan bir kurulumda klasör aşağıdaki gibidir:

| Rapor sunucusu | Varsayılan *ReportServer* klasörü |
| :- | :- |
| SQL Server 2017 ve sonraki Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 ve daha eski Reporting Services | `C:\Program Files\Microsoft SQL Server\<instance folder>\Reporting Services\ReportServer`, burada örnek klasörü örneğin SQL Server 2016 için `MSRS13.MSSQLSERVER` veya SQL Server 2005 için `MSSQL.x` gibi bir isimdir |

Daha fazla konum için Microsoft'un [RsReportServer.config yapılandırma dosyası](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file) makalesine bakın.

## **Uzantıyı Yükleyin**

1. Seçtiğiniz derlemeyi *ReportServer* klasörünün *bin* alt klasörüne kopyalayın.

   Kopyalanan dosyada açıkça atanmış NTFS izinleri olmamalıdır; aksi takdirde rapor sunucusu derlemeyi yüklerken erişimi reddeder ve yeni dışa aktarma formatları görünmez. Dosyaya sağ tıklayın, **Properties** (Özellikler) seçeneğini açın ve **Security** (Güvenlik) sekmesinde açıkça atanmış izinleri kaldırarak yalnızca kalıtılanları bırakın. **General** (Genel) sekmesinde **Unblock** (Engeli Kaldır) seçeneği varsa işaretleyin.

1. *rsreportserver.config* dosyasının bir kopyasını kaydedin ve ardından bir metin düzenleyicide açın. `<Render>` öğesi içinde aşağıdaki girişleri ekleyin:

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   Her giriş bir dışa aktarma formatı kaydeder; `Name` değeri render uzantıları arasında benzersiz olmalıdır. MSI yükleyicisi aynı altı adı ve türü kaydeder. Listeye istediğiniz formatı eklemek istemiyorsanız ilgili girişi atlayın.

1. *rssrvpolicy.config* dosyasının bir kopyasını kaydedin ve ardından bir metin düzenleyicide açın. `Description` değeri "This code group grants MyComputer code Execution permission." olan kod grubunu bulun ve aşağıdaki kod grubunu son alt öğe olarak ekleyin:

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob`, Aspose.Slides.ReportingServices derlemesinin ortak anahtarıdır. Tek satırda tutun.

1. İki dosyayı da kaydedin. Rapor sunucusu, dosyalar kaydedildiğinde yapılandırma dosyalarını yeniden okur. Bir dosyada hatalı XML bulunursa, rapor sunucusu dosyayı yok sayar ya da başlatılamaz; bu durumda kopyanızı geri yükleyin.

## **Kurulumu Kontrol Edin**

Web portalında (SQL Server 2014 ve öncesi için Report Manager) bir sayfalı raporu açın ve **Export** (Dışa Aktar) menüsünü görüntüleyin. Artık aşağıdaki formatlar listelenir:

- PPT - PowerPoint Sunumu via Aspose.Slides
- PPS - PowerPoint Slayt Gösterisi via Aspose.Slides
- PPTX - PowerPoint 2007 Sunumu via Aspose.Slides
- PPSX - PowerPoint 2007 Slayt Gösterisi via Aspose.Slides
- ODP - OpenDocument Sunumu via Aspose.Slides
- XPS - via Aspose.Slides

Bu formatlardan birini seçerek raporu dışa aktarın. Dosya, ilgili formatla ilişkilendirilmiş uygulamada açılır.

![Aspose.Slides for Reporting Services ile PowerPoint'e dışa aktarılan bir rapor](install-manually_2.png)

Formatlar görünmüyorsa, kopyalanan derlemenin NTFS izinlerini kontrol edin. Lisans olmadan dışa aktarılan dosyalar değerlendirme filigranı içerir; bkz. [Lisanslama](/slides/tr/reportingservices/license-aspose-slides-for-reporting-services/).