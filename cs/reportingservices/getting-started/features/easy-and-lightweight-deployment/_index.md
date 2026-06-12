---
title: Jednoduché a lehké nasazení
type: docs
weight: 50
url: /cs/reportingservices/easy-and-lightweight-deployment/
---
{{% alert color="primary" %}}

Aspose.Slides for Reporting Services je [renderovací rozšíření](http://msdn2.microsoft.com/en-us/library/ms154606.aspx) pro Microsoft SQL Server Reporting Services.  
Aspose.Slides for Reporting Services je poskytován jako jediný MSI instalátor, který lze nainstalovat na počítače, na nichž běží některá z následujících:

- Microsoft SQL Server 2005 Reporting Services (32-bit and 64-bit)
- Microsoft SQL Server 2008 Reporting Services (32-bit and 64-bit)

Nasazení a správa Aspose.Slides for Reporting Services ručně je také snadná, protože se skládá pouze z jedné .NET sestavy *Aspose.Slides* *.ReportingServices.dll*, která je kompletně napsána v C#, je kompatibilní s CLS a obsahuje pouze bezpečný řízený kód.

{{% /alert %}}

MSI instalátor a ZIP ke stažení obsahují Aspose.Slides for ReportingServices:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – kompilováno pro Microsoft SQL Server 2005 a .NET Framework 2.0 (použitelné pro x86 a x64)
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll – kompilováno pro Microsoft SQL Server 2008 a .NET Framework 2.0 (použitelné pro x86 a x64)

Při instalaci je soubor Aspose.Slides.ReportingServices.dll zkopírován do adresáře ReportServer\bin a konfigurační soubor je aktualizován, aby Reporting Services byl informován o novém renderovacím rozšíření. Tyto kroky provádí instalátor Aspose.Slides for Reporting Services, ale můžete je také provést ručně, jak je popsáno dále v této dokumentaci.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Obrázek**: Aspose.Slides.ReportingServices.dll je zkopírován do adresáře **ReportServer\bin**.