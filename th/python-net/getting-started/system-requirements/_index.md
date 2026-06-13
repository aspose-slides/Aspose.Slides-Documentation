---
title: ข้อกำหนดระบบ
type: docs
weight: 60
url: /th/python-net/system-requirements/
keywords:
- ข้อกำหนดระบบ
- ระบบปฏิบัติการ
- การติดตั้ง
- การพึ่งพา
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบข้อกำหนดระบบของ Aspose.Slides for Python via .NET. รับประกันการสนับสนุน PowerPoint และ OpenDocument อย่างราบรื่นบน Windows, Linux และ macOS."
---
## **คำนำ**

Aspose.Slides for Python ผ่าน .NET ไม่ต้องการผลิตภัณฑ์ของบุคคลที่สามใด ๆ เช่น Microsoft PowerPoint เพื่อติดตั้ง Aspose.Slides เป็นเครื่องมือสำหรับสร้าง แก้ไข แปลง และแสดงผลเอกสารในรูปแบบต่าง ๆ รวมถึงรูปแบบการนำเสนอของ Microsoft PowerPoint

## **ระบบปฏิบัติการที่รองรับ**

Aspose.Slides for Python รองรับ Windows (32-bit และ 64-bit) macOS และ Linux 64-bit บนระบบที่ติดตั้ง Python 3.5 หรือเวอร์ชันใหม่กว่า

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">ระบบปฏิบัติการ</td>
        <td style="font-weight: bold; width:400px">เวอร์ชัน</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows 2003 Server</li>
                <li>Windows 2008 Server</li>
                <li>Windows 2012 Server</li>
                <li>Windows 2012 R2 Server</li>
                <li>Windows 2016 Server</li>
                <li>Windows 2019 Server</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Linux</td>
        <td>
            <ul>
                <li>Ubuntu</li>
                <li>OpenSUSE</li>
                <li>CentOS</li>
                <li>และอื่น ๆ</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>macOS</td>
        <td>
            <ul>
                <li>12 "Monterey"</li>
            </ul>
        </td>
    </tr>
</table>

## **ความต้องการระบบสำหรับแพลตฟอร์ม Linux และ macOS**

- ไลบรารีรันไทม์ GCC 6 (หรือใหม่กว่า).
- [libgdiplus](https://github.com/mono/libgdiplus) เป็นการนำไปใช้แบบโอเพนซอร์สของ API GDI+.
- การพึ่งพาของ .NET Core Runtime การติดตั้ง .NET Core Runtime เองไม่จำเป็น
- สำหรับ Python 3.5–3.7: ต้องใช้การสร้าง Python แบบ `pymalloc`. ตัวเลือกการสร้าง `--with-pymalloc` ถูกเปิดใช้งานตามค่าเริ่มต้น. โดยทั่วไป การสร้าง Python แบบ `pymalloc` จะมีสัญลักษณ์ `m` ต่อท้ายในชื่อไฟล์.
- `libpython` ไลบรารีแบบ shared. ตัวเลือกการสร้าง Python `--enable-shared` ถูกปิดใช้งานตามค่าเริ่มต้น และบางการแจกจ่ายของ Python ไม่รวมไลบรารี `libpython` แบบ shared. บนบางแพลตฟอร์ม Linux คุณสามารถติดตั้งไลบรารี `libpython` แบบ shared โดยใช้ตัวจัดการแพ็กเกจ (เช่น `sudo apt-get install libpython3.7`). ปัญหาที่พบบ่อยคือไลบรารี `libpython` ถูกติดตั้งในตำแหน่งที่ไม่เป็นมาตรฐานสำหรับไลบรารีแบบ shared. คุณสามารถแก้ไขได้โดยใช้ตัวเลือกการสร้างของ Python เพื่อกำหนดเส้นทางไลบรารีทางเลือกเมื่อคอมไพล์ Python หรือโดยการสร้างลิงก์สัญลักษณ์ไปยังไฟล์ไลบรารี `libpython` ในตำแหน่งไลบรารีแบบ shared มาตรฐานของระบบ. โดยปกติชื่อไฟล์ไลบรารี `libpython` แบบ shared จะเป็น `libpythonX.Ym.so.1.0` สำหรับ Python 3.5–3.7 หรือ `libpythonX.Y.so.1.0` สำหรับ Python 3.8 หรือใหม่กว่า (เช่น `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **คำถามที่พบบ่อย**

**ฉันต้องการ Microsoft PowerPoint ติดตั้งเพื่อการแปลงและการแสดงผลหรือไม่?**

ไม่, PowerPoint ไม่จำเป็น; Aspose.Slides เป็นเครื่องมือแยกเดียวสำหรับ [การสร้าง](/slides/th/python-net/create-presentation/), การแก้ไข, [การแปลง](/slides/th/python-net/convert-presentation/), และ [การแสดงผล](/slides/th/python-net/convert-powerpoint-to-png/) การนำเสนอ.

**จำเป็นต้องมีเวอร์ชัน .NET เฉพาะ (Core/5+/6+) บนเครื่องหรือไม่?**

การติดตั้ง .NET Runtime เองไม่จำเป็น แต่ต้องมีการพึ่งพาที่จำเป็นบน Linux/macOS. ซึ่งหมายความว่าระบบควรมีแพ็กเกจที่โดยปกติจะติดตั้งเป็นการพึ่งพาของ .NET โดยไม่ต้องติดตั้ง runtime อย่างเต็มรูปแบบ.

**ต้องการฟอนต์ใดสำหรับการแสดงผลที่ถูกต้อง?**

โดยปฏิบัติ ฟอนต์ที่ใช้ในการนำเสนอหรือ [ตัวทดแทน](/slides/th/python-net/font-substitution/) ที่เหมาะสมต้องพร้อมใช้งาน. เพื่อให้การแสดงผลสอดคล้องกันบน Linux/macOS แนะนำให้ติดตั้งแพ็กเกจฟอนต์ทั่วไป.

**ทำไมฟอนต์ที่กำหนดเองจึงแสดงเป็นแบบ fallback หรือข้อความหายไปบน Linux?**

หากไฟล์ฟอนต์มีรายการในตารางชื่อไม่สอดคล้องหรือเสียหาย, stack การจับคู่ฟอนต์ของ Linux (FreeType/fontconfig) อาจเลือกบันทึกที่ไม่ถูกต้อง, ทำให้ฟอนต์ไม่สามารถระบุได้. การใช้เวอร์ชันฟอนต์ที่แก้ไขรายการในตารางชื่อหรือการติดตั้งการทดแทนที่สอดคล้องจะช่วยแก้ปัญหา.