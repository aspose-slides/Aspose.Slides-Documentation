---
title: Aspose.Slides for SharePoint Lisansını Kurma
type: docs
weight: 10
url: /tr/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "Aspose.Slides for SharePoint lisansını bir SharePoint çiftliğine kurun: lisans çözümünü çözüm deposuna ekleyin, dağıtın ve dönüştürülen dosyaların artık değerlendirme filigranı taşımadığını kontrol edin."
---
{{% alert color="info" title="Note" %}}

Değerlendirmenizi memnuniyetle tamamladıktan sonra bir lisans [satın alabilirsiniz](https://purchase.aspose.com/pricing/slides/tr/sharepoint/). Satın almadan önce lisans abonelik koşullarını anladığınızdan ve kabul ettiğinizden emin olun. Sipariş ödenince lisans size e-posta ile gönderilir.

Lisans, normal bir SharePoint çözüm paketi içeren bir ZIP arşividir. Arşiv şunları içerir:

- Aspose.Slides.SharePoint.License.wsp – SharePoint çözüm paketi dosyası. Lisans, bir sunucu çiftliğinde dağıtımı ve geri çekmeyi kolaylaştırmak için SharePoint çözümü olarak paketlenir.
- readme.txt – Lisans kurulum talimatları.

{{% /alert %}}

## **Lisansı Dağıtma**

Lisans kurulumu, sunucu konsolundan **stsadm.exe** aracılığıyla gerçekleştirilir.

{{% alert color="info" title="Note" %}}

Aşağıdaki bölümde açıklık sağlamak için yollar atlanmıştır.

{{% /alert %}}

Aspose.Slides for SharePoint lisansını dağıtmak için aşağıdaki adımları izleyin:

1. Çözümü SharePoint çözüm deposuna eklemek için stsadm'i çalıştırın:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. Çözümü çiftlikteki tüm sunuculara dağıtın:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. Dağıtımı hemen tamamlamak için yönetim zamanlayıcı işlerini çalıştırın:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

`addsolution` işlemi, çözüm dosyasının yolunu `-filename` parametresinde alır; `deploysolution` işlemi, zaten çözüm deposunda bulunan çözümün adını `-name` parametresinde alır.

{{% alert color="info" title="Note" %}}

Dağıtım adımını çalıştırırken SharePoint Yönetim hizmeti çalışmıyorsa bir uyarı alırsınız. **stsadm.exe**, çiftlikte çözüm verilerini çoğaltmak için bu hizmete ve SharePoint Zamanlayıcı hizmetine dayanır. Bu hizmetler sunucu çiftliğinizde çalışmıyorsa, lisansı her sunucuya dağıtmanız gerekebilir.

{{% /alert %}}

{{% alert color="info" title="Note" %}}

SharePoint 2010 ve sonraki sürümlerde, SharePoint Yönetim Shell cmdlet'leri `Add-SPSolution`, `Install-SPSolution` ve `Start-SPAdminJob` sırasıyla `addsolution`, `deploysolution` ve `execadmsvcjobs` işlemlerine karşılık gelir. Bkz. [Stsadm to Microsoft PowerShell mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).

{{% /alert %}}

## **Lisansı Test Etme**

Lisansın doğru bir şekilde kurulduğunu test etmek için herhangi bir sunumu yeni bir formata dönüştürün. Dönüştürülmüş dosyada değerlendirme filigranı yoksa, lisans aktiftir.