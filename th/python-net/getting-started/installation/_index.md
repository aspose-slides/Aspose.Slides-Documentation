---
title: การติดตั้ง
type: docs
weight: 70
url: /th/python-net/installation/
keywords:
- ดาวน์โหลด Aspose.Slides
- ติดตั้ง Aspose.Slides
- ใช้งาน Aspose.Slides
- การติดตั้ง Aspose.Slides
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "ติดตั้ง Aspose.Slides สำหรับ Python ผ่าน .NET จาก PyPI ด้วย pip บน Windows, Linux, และ macOS พร้อมติดตั้งไลบรารีเนทีฟที่ Linux และ macOS ต้องการ."
---
## **Overview**

บทความนี้อธิบายวิธีการติดตั้ง Aspose.Slides สำหรับ Python ผ่าน .NET บน Windows, Linux, และ macOS แพ็กเกจถูกเผยแพร่บน [PyPI](https://pypi.org/project/aspose.slides/) และติดตั้งด้วย pip มันรวม runtime ของ .NET ที่ใช้ไว้แล้ว ดังนั้นคุณจึงไม่ต้องติดตั้ง .NET บน Linux และ macOS runtime นี้ต้องการไลบรารีเนทีฟที่ระบบปฏิบัติการอาจไม่ได้รวมไว้; ส่วนต่อไปนี้จะระบุชื่อไลบรารีเหล่านั้น

Aspose.Slides สำหรับ Python ผ่าน .NET รองรับ Python 3.5 ถึง 3.14 PyPI ให้แพ็กเกจสำหรับ Windows (32‑bit และ 64‑bit), Linux (x86_64 และ ARM64), และ macOS (Intel และ Apple silicon)

## **Windows**

บน Windows ให้ติดตั้งแพ็กเกจด้วย pip ไม่จำเป็นต้องมีไลบรารีอื่นใด

```bash
pip install aspose.slides
```

## **Linux**

บน Linux runtime .NET ที่รวมอยู่ในแพ็กเกจต้องการไลบรารีสองตัว:

- **libgdiplus** การทำงานของ API กราฟิก Windows GDI+ หากไม่มีจะทำให้การบันทึกงานนำเสนอล้มเหลวด้วยข้อผิดพลาด `The type initializer for 'Gdip' threw an exception`
- **ICU** (International Components for Unicode) หากไม่มีจะทำให้กระบวนการ Python สิ้นสุดที่การเรียก Aspose.Slides ครั้งแรกโดยแสดงข้อความ `Couldn't find a valid ICU package installed on the system`

บน Debian และ Ubuntu ให้ติดตั้งทั้งสองด้วย apt:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

ชื่อของแพ็กเกจ ICU มีเวอร์ชันระบุไว้: `libicu76` เป็นแพ็กเกจสำหรับ Debian 13 ใน Debian 12 ให้ติดตั้ง `libicu72` แทน และบน Ubuntu 24.04 ให้ใช้ `libicu74` เพื่อค้นหาชื่อบนระบบของคุณ ให้รัน:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

จากนั้นติดตั้งแพ็กเกจลงใน virtual environment บน Debian และ Ubuntu รุ่นปัจจุบัน Python ของระบบไม่อนุญาตให้ `pip install` นอก virtual environment และจะหยุดทำงานด้วยข้อผิดพลาด `externally-managed-environment`

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

เรียกใช้สคริปต์ของคุณด้วย virtual environment ที่เปิดใช้งานอยู่ หากคุณใช้ Python ที่การจัดแจกของคุณไม่ได้จัดการ เช่น Python ในภาพ Docker อย่างเป็นทางการ `python` คุณก็สามารถรัน `pip install aspose.slides` โดยไม่ต้องใช้ virtual environment ได้เช่นกัน

แบบอักษรที่ใช้ในงานนำเสนอของคุณ หรือแบบอักษรทดแทนที่เหมาะสม ต้องถูกติดตั้งบนระบบเพื่อให้ข้อความแสดงผลอย่างถูกต้องเมื่อแปลงสไลด์เป็น PDF หรือรูปภาพ

## **macOS**

เรายังไม่ได้ตรวจสอบการติดตั้งบน macOS บน macOS Aspose.Slides ต้องการข้อกำหนดเบื้องต้นต่อไปนี้:

- **Python with shared libraries** คือ Python ที่สร้างด้วยตัวเลือกกำหนดค่า `--enable-shared` หากคุณติดตั้ง Python ด้วย [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos) ให้ตั้งตัวแปรสภาพแวดล้อม `PYTHON_CONFIGURE_OPTS` เป็น `--enable-shared` ขณะติดตั้งเวอร์ชัน Python
- **The libpython library in a system library directory** Python ที่ติดตั้งด้วย pyenv จะเก็บไลบรารี libpython เช่น *libpython3.9.dylib* ที่ *~/.pyenv/versions*; สร้าง symbolic link ไปยังไดเรกทอรี */usr/local/lib*
- **libgdiplus** การทำงานของ API กราฟิก Windows GDI+ Homebrew มีให้ในแพ็กเกจ `mono-libgdiplus`

จากนั้นติดตั้งแพ็กเกจด้วย pip

## **Check the Installation**

เพื่อตรวจสอบการติดตั้ง ให้บันทึกตัวอย่างแรกใน [Create Presentations](/slides/th/python-net/create-presentation/) เป็นไฟล์ *hello.py* แล้วรัน `python hello.py` ซึ่งจะบันทึกไฟล์ *new_presentation.pptx* ลงในโฟลเดอร์ปัจจุบัน

## **Upgrade**

เพื่ออัปเกรดการติดตั้งที่มีอยู่ให้เป็นเวอร์ชันล่าสุด ให้รันคำสั่งนี้ในสภาพแวดล้อมที่คุณติดตั้งแพ็กเกจ:

```bash
pip install --upgrade aspose.slides
```

## **FAQ**

**Can I install Aspose.Slides in a virtual environment?**

ใช่ คุณสามารถติดตั้งได้ใน virtual environment ของ Python ใดก็ได้ด้วย pip ไลบรารีเนทีฟที่ Linux และ macOS ต้องการจะถูกติดตั้งบนระบบ ไม่ได้อยู่ใน virtual environment

**Can I use Aspose.Slides in Docker containers?**

ใช่ ภาพ Docker ต้องรวมไลบรารีเนทีฟเดียวกับระบบ Linux — libgdiplus และ ICU — รวมถึงแบบอักษรที่งานนำเสนอของคุณใช้

**Is there a free version or trial limitation?**

ใช่ หากไม่มีไลเซนส์ Aspose.Slides จะทำงานในโหมดประเมินผล: จะเพิ่มลายน้ำประเมินผลในทุกสไลด์ที่บันทึกและตัดข้อความที่อ่านจากงานนำเสนอออก หากต้องการขจัดข้อจำกัดเหล่านี้ ให้ใช้ [license](/slides/th/python-net/licensing/) ที่ถูกต้อง