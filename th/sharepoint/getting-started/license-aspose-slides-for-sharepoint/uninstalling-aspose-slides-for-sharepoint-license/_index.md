---
title: การถอนการติดตั้งใบอนุญาต Aspose.Slides สำหรับ SharePoint
type: docs
weight: 20
url: /th/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---
หากต้องการยกเลิกการติดตั้งใบอนุญาต โปรดทำตามขั้นตอนด้านล่างจากคอนโซลของเซิร์ฟเวอร์

1. ถอนโซลูชันใบอนุญาตออกจากฟาร์ม:

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. เรียกใช้งานตัวจับเวลาระดับผู้ดูแลเพื่อให้การถอนเสร็จสมบูรณ์โดยทันที:

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. รอให้การถอนเสร็จสมบูณ์ คุณสามารถใช้ Central Administration เพื่อตรวจสอบว่าการถอนเสร็จสิ้นหรือไม่ ภายใต้ **Central Administration** แล้วเลือก **Operations** และ **Solution Management**.

4. ลบโซลูชันออกจากที่เก็บโซลูชันของ SharePoint:

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```