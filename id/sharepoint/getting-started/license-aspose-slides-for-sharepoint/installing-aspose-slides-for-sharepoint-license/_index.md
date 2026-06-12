---
title: Menginstal Lisensi Aspose.Slides untuk SharePoint
type: docs
weight: 10
url: /id/sharepoint/installing-aspose-slides-for-sharepoint-license/
---
{{% alert color="primary" %}} 

Setelah Anda puas dengan evaluasi Anda, Anda dapat [purchase a license](https://purchase.aspose.com/buy). Sebelum membeli, pastikan Anda memahami dan menyetujui ketentuan langganan lisensi. Lisensi akan dikirimkan ke email Anda setelah pesanan dibayar.

Lisensi berupa arsip ZIP yang berisi paket solusi SharePoint standar. Arsip tersebut berisi:

- Aspose.Slides.SharePoint.License.wsp – file paket solusi SharePoint. Lisensi dikemas sebagai solusi SharePoint untuk memudahkan penyebaran dan penarikan di seluruh farm server.
- readme.txt – Instruksi instalasi lisensi.

{{% /alert %}} 
## **Deploying the License**
Instalasi lisensi dilakukan dari konsol server melalui **stsadm.exe**.

{{% alert color="primary" %}} 

Path-path dihilangkan pada bagian berikut untuk kejelasan.

{{% /alert %}} 

Lakukan langkah-langkah berikut untuk menyebarkan lisensi Aspose.Slides untuk SharePoint:

1. Jalankan stsadm untuk menambahkan solusi ke penyimpanan solusi SharePoint: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. Sebarkan solusi ke semua server di farm: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. Jalankan pekerjaan timer administratif untuk menyelesaikan penyebaran segera: 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

Anda akan menerima peringatan saat menjalankan langkah penyebaran jika layanan Windows SharePoint Services Administration tidak berjalan. **stsadm.exe** bergantung pada layanan ini dan Windows SharePoint Timer Service untuk mereplikasi data solusi di seluruh farm. Jika layanan tersebut tidak berjalan di farm server Anda, Anda mungkin perlu menyebarkan lisensi pada setiap server. 

{{% /alert %}} 
## **Test the License**
Untuk menguji bahwa lisensi telah terinstal dengan benar, konversi dokumen apa pun ke format baru. Jika tidak ada watermark evaluasi pada dokumen, lisensi telah berhasil diaktifkan.