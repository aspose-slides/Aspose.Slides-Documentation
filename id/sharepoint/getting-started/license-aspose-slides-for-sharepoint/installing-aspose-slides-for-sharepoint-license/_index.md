---
title: Instalasi Lisensi Aspose.Slides untuk SharePoint
type: docs
weight: 10
url: /id/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "Instal lisensi Aspose.Slides untuk SharePoint pada farm SharePoint: tambahkan solusi lisensi ke penyimpanan solusi, sebarkan, dan periksa bahwa file yang dikonversi tidak lagi menampilkan watermark evaluasi."
---
{{% alert color="info" title="Note" %}}

Setelah Anda puas dengan evaluasi Anda, Anda dapat [membeli lisensi](https://purchase.aspose.com/pricing/slides/id/sharepoint/). Sebelum membeli, pastikan Anda memahami dan menyetujui ketentuan langganan lisensi. Lisensi akan dikirimkan ke email Anda setelah pesanan dibayar.

Lisensi berupa arsip ZIP yang berisi paket solusi SharePoint standar. Arsip tersebut berisi:

- Aspose.Slides.SharePoint.License.wsp – file paket solusi SharePoint. Lisensi dikemas sebagai solusi SharePoint untuk memudahkan penyebaran dan penarikan kembali di seluruh farm server.
- readme.txt – Instruksi pemasangan lisensi.

{{% /alert %}}

## **Deploying the License**

Pemasangan lisensi dilakukan dari konsol server melalui **stsadm.exe**.

{{% alert color="info" title="Note" %}}

Jalur file dihilangkan pada bagian berikut untuk kejelasan.

{{% /alert %}}

Lakukan langkah-langkah berikut untuk menyebarkan lisensi Aspose.Slides untuk SharePoint:

1. Jalankan stsadm untuk menambahkan solusi ke penyimpanan solusi SharePoint:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. Sebarkan solusi ke semua server di farm:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. Jalankan pekerjaan timer administratif untuk menyelesaikan penyebaran segera:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

Operasi `addsolution` menerima path file solusi pada argumen `-filename`; operasi `deploysolution` menerima nama solusi yang sudah ada di penyimpanan solusi pada argumen `-name`.

{{% alert color="info" title="Note" %}}

Anda akan menerima peringatan saat menjalankan langkah penyebaran jika layanan SharePoint Administration tidak berjalan. **stsadm.exe** bergantung pada layanan ini serta layanan SharePoint Timer untuk mereplikasi data solusi di seluruh farm. Jika layanan tersebut tidak berjalan pada farm server Anda, Anda mungkin perlu menyebarkan lisensi pada setiap server.

{{% /alert %}}

{{% alert color="info" title="Note" %}}

Pada SharePoint 2010 dan versi lebih baru, cmdlet SharePoint Management Shell `Add-SPSolution`, `Install-SPSolution`, dan `Start-SPAdminJob` sesuai dengan operasi `addsolution`, `deploysolution`, dan `execadmsvcjobs`. Lihat [Stsadm to Microsoft PowerShell mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).

{{% /alert %}}

## **Test the License**

Untuk menguji bahwa lisensi telah terpasang dengan benar, konversi presentasi apa pun ke format baru. Jika tidak ada watermark evaluasi pada file yang dikonversi, lisensi aktif.