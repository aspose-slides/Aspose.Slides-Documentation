---
title: Mencopot Lisensi Aspose.Slides untuk SharePoint
type: docs
weight: 20
url: /id/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---
Untuk mencopot lisensi, silakan gunakan langkah‑langkah di bawah ini dari konsol server. 

1. Tarik kembali solusi lisensi dari farm: 

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. Jalankan pekerjaan timer administratif untuk menyelesaikan penarikan segera: 

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. Tunggu hingga penarikan selesai. Anda dapat menggunakan Central Administration untuk memeriksa apakah penarikan selesai di bawah **Central Administration**, lalu **Operations** dan **Solution Management**.
4. Hapus solusi dari penyimpanan solusi SharePoint: 

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```