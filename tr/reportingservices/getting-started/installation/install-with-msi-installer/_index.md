---
title: MSI Yükleyicisi ile Kurulum
type: docs
weight: 20
url: /tr/reportingservices/install-with-msi-installer/
keywords:
- MSI yükleyici
- kurulum
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Aspose.Slides for Reporting Services'ı MSI yükleyicisi ile kurun: yükleyicinin neye ihtiyacı var, her rapor sunucusu örneğinde neyi değiştirir ve sonucu nasıl kontrol edersiniz."
---
## **Kurulum**

MSI yükleyicisi, Aspose.Slides for Reporting Services'ı kurmanın en basit yoludur. .NET Framework 3.5 ve rapor sunucusunda yönetici hakları gerektirir; bkz. [System Requirements](/slides/tr/reportingservices/system-requirements/).

1. MSI yükleyicisini, *Aspose.Slides for Reporting Services XX.XX*, [indirme sayfasından](https://releases.aspose.com/slides/reportingservices/) indirin ve rapor sunucusuna kopyalayın.
1. Yönetici olarak çalıştırın. .NET Framework 3.5 eksikse, yükleyici bir mesajla durur; .NET Framework 3.5 özelliklerini kurun ve yeniden çalıştırın.
1. Lisans sözleşmesini kabul edin.
1. **Custom Setup** sayfasında, özellik ağacı, yükleyicinin makinede algıladığı her SQL Server Reporting Services ve Power BI Report Server örneğini listeler. Bir örneği değiştirmeden bırakmak için, simgesine tıklayın ve **Entire feature will be unavailable** seçeneğini işaretleyin. Express sürümleri render uzantılarını desteklemez, bu yüzden bir Express örneği seçmeyin. Yükleyici, SQL Server 2016 ve öncesinin Express örneklerini gizler.
1. **Next** seçin, ardından **Install**.

Opsiyonel **Rpl Export** özelliği varsayılan olarak seçilmez. RPL formatında raporları kaydeden gizli bir uzantı ekler; bu, bir sorun raporunu Aspose'a gönderdiğinizde faydalıdır; bkz. [Exporting Reports to RPL Format](/slides/tr/reportingservices/exporting-reports-to-rpl-format/).

## **Yükleyicinin Yaptıkları**

Yükleyici dosyalarını *Aspose\Aspose.Slides for Reporting Services* klasöründe tutar — 64-bit Windows'ta *Program Files (x86)* altında, çünkü yükleyici 32-bit bir pakettir. Ardından, seçilen her örnek için:

- *Aspose.Slides.ReportingServices.dll* dosyasını örnek içindeki *ReportServer\bin* klasörüne kopyalar — SQL Server 2005 için derleme ya da SQL Server 2008 ve sonrası ve Power BI Report Server için derleme;
- *rsreportserver.config* dosyasının `<Render>` öğesine altı render uzantısı — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS ve ASODP — ekler;
- *rssrvpolicy.config* dosyasına derlemeye tam güven veren bir kod grubu ekler;
- Değiştirdiği her yapılandırma dosyasının bir kopyasını, dosya adına *.bak* ekleyerek kaydeder.

[Install Manually](/slides/tr/reportingservices/install-manually/) bu değişiklikleri adım adım gösterir.

Bir örnek yapılandırılamazsa, yükleyici mesajda adını belirtir ve detayları kurulum klasöründeki *rserrors<date>.log* dosyasına yazar. Uzantıyı o örnek üzerinde manuel olarak kurun.

## **Kurulumu Kontrol Edin**

Web portalında (SQL Server 2014 ve önceki sürümlerde Report Manager) bir sayfalandırılmış rapor açın ve **Export** listesini açın. Şimdi şu formatlar yer alıyor:

- PPT - PowerPoint Presentation via Aspose.Slides
- PPS - PowerPoint SlideShow via Aspose.Slides
- PPTX - PowerPoint 2007 Presentation via Aspose.Slides
- PPSX - PowerPoint 2007 SlideShow via Aspose.Slides
- ODP - OpenDocument Presentation via Aspose.Slides
- XPS - via Aspose.Slides

Bir lisans olmadan, dışa aktarılan dosyalar değerlendirme filigranı taşır; bkz. [Licensing](/slides/tr/reportingservices/license-aspose-slides-for-reporting-services/).

## **Ne Zaman Manuel Olarak Kurulur?**

Uzantıyı [manually](/slides/tr/reportingservices/install-manually/) aşağıdaki durumlarda kurun:

- Yükleyici bir örneği yapılandıramaz, örneğin sunucudaki güvenlik ayarları nedeniyle;
- Bir yükseltmeden sonra sadece derlemeyi değiştirmek isterseniz, eski sürümü kaldırıp yeni yükleyiciyi çalıştırmak yerine.

Ürünü kaldırmak, derlemeyi ve yapılandırma girdilerini her örnekten siler.