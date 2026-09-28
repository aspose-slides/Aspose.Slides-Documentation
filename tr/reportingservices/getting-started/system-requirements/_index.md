---
title: Sistem Gereksinimleri
type: docs
weight: 15
url: /tr/reportingservices/system-requirements/
keywords:
- sistem gereksinimleri
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "Aspose.Slides for Reporting Services'in kurulumundan önce hangi rapor sunucularının, sürümlerin ve .NET Framework sürümünün gerektiğini kontrol edin."
---
## **Genel Bakış**

Aspose.Slides for Reporting Services, rapor sunucusunda bir render uzantısı olarak çalışır. Bu sayfa, rapor sunucusu makinesinin [kur](/slides/tr/reportingservices/installing-aspose-slides-for-reporting-services/) öncesinde neye ihtiyacı olduğunu listeler. Microsoft PowerPoint ve Microsoft Office gerekli değildir.

## **Desteklenen Rapor Sunucuları**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 and 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, for paginated (RDL) reports

Hem 32-bit hem de 64-bit rapor sunucuları desteklenir. SQL Server 2005 uzantının kendi derlemesini kullanır; sonraki tüm sürümler ve Power BI Report Server aynı derlemeyi kullanır. [Manuel Olarak Kur](/slides/tr/reportingservices/install-manually/) hangi dosyanın kopyalanacağını gösterir.

Eğer rapor sunucusu sürümünüz bu listede yoksa, dağıtmadan önce [ücretsiz destek forumu](https://forum.aspose.com/c/slides/11) adresinde sorun.

## **Rapor Sunucusu Sürümleri**

SQL Server 2016 Reporting Services ve sonraki sürümler için ve Power BI Report Server için, Microsoft Enterprise, Standard, Developer ve Evaluation sürümlerinde render uzantılarını destekler; Web ve Express sürümleri bunları desteklemez. [Sürümlere göre Reporting Services özellikleri](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server) adresine bakın. MSI yükleyicisi SQL Server 2016 ve öncesinin Express sürüm örneklerini atlar.

## **.NET Framework**

.NET Framework 3.5, rapor sunucusu makinesine kurulmalıdır. Uzantının derlemeleri .NET Framework 2.0 çalışma zamanı için derlenmiştir ve MSI yükleyicisi .NET Framework 3.5 eksikse bir mesajla durur. Windows Server'da, Rolleri ve Özellikleri Ekle Sihirbazı'nda **.NET Framework 3.5 Features** ekleyin; [Windows'ta .NET Framework 3.5'i Kur](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows) adresine bakın.

## **İzinler**

Uzantıyı kurmak, rapor sunucusu klasöründeki dosyaları değiştirir, bu yüzden her iki kurulum yöntemi de yerel yönetici hakları gerektirir. MSI yükleyicisini bunlar olmadan başlatırsanız, kendini yönetici ayrıcalıklarıyla yeniden başlatma seçeneği sunar.

## **SSS**

**Rapor sunucusunda Microsoft PowerPoint'e ihtiyacım var mı?**

Hayır. Uzantı sunumları kendisi oluşturur; PowerPoint ya da Microsoft Office kurulmak zorunda değildir.

**Uzantıyı Express sürümüne kurabilir miyim?**

Hayır. Express sürümleri render uzantılarını desteklemez. MSI yükleyicisi SQL Server 2016 ve öncesinin Express örneklerini gizler; sonraki sürümlerde Express bir örnek seçmeyin.

**Uzantı dışa aktarma listesine hangi formatları ekler?**

PPT, PPS, PPTX, PPSX, ODP ve XPS. [Desteklenen Dosya Formatları](/slides/tr/reportingservices/supported-file-formats/).