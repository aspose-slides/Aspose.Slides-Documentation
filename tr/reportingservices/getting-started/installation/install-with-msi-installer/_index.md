---
title: MSI Yükleyicisiyle Kurulum
type: docs
weight: 20
url: /tr/reportingservices/install-with-msi-installer/
---
## **Kurulum**
Aspose.Slides for Reporting Services'ı bir MSI yükleyicisi aracılığıyla kurabilirsiniz. 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services**'ın çalıştığı makinede **.NET Framework 3.5** kurulu olmalıdır. 

{{% /alert %}}

***Aspose.Slides.ReportingServices.msi*** dosyasını çalıştırın ve yükleyicinin sunduğu adımları izleyin. 

Yükleyici, derlemeyi ve diğer dosyaları belirtilen dizine kopyalar ve ürünü varsayılan Reporting Services örneğine kurar. Özel yapılandırma parametreleri eklemek istemediğiniz sürece dosyaları manuel olarak kopyalamanız veya değiştirmeniz gerekmez. 

MSI yükleyicisini içeren kurulum çoğu durumda en iyi seçenektir. Bununla birlikte, bazı durumlarda ürünü manuel olarak kurmak isteyebilirsiniz: 

- Güvenlik sorunları veya diğer nedenlerden dolayı otomatik kurulum başarısız olur. 
- Ürün, Reporting Services'in adlandırılmış (varsayılan olmayan) bir örneğine veya birden fazla örneğe kurulmalıysa. 
- En son sürüme yükselttikten sonra, eski sürümü kaldırıp MSI yükleyicisiyle yeni sürümü kurmak yerine yalnızca derlemeyi değiştirmek isteyebilirsiniz. **Not** bu durumda başka dosyalar da kalabilir.