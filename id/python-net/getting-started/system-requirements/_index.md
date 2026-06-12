---
title: Persyaratan Sistem
type: docs
weight: 60
url: /id/python-net/system-requirements/
keywords:
- persyaratan sistem
- sistem operasi
- instalasi
- ketergantungan
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Temukan persyaratan sistem Aspose.Slides untuk Python via .NET. Pastikan dukungan PowerPoint dan OpenDocument yang mulus di Windows, Linux, dan macOS."
---
## **Pendahuluan**

Aspose.Slides for Python via .NET tidak memerlukan produk pihak ketiga apa pun, seperti Microsoft PowerPoint, untuk diinstal. Aspose.Slides adalah mesin untuk membuat, memodifikasi, mengonversi, dan merender dokumen dalam berbagai format, termasuk format presentasi Microsoft PowerPoint.

## **Sistem Operasi yang Didukung**

Aspose.Slides for Python mendukung Windows (32-bit dan 64-bit), macOS, dan Linux 64-bit pada sistem dengan Python 3.5 atau yang lebih baru terinstal.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">Sistem Operasi</td>
        <td style="font-weight: bold; width:400px">Versi</td>
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
                <li>dan lain-lain</li>
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

## **Persyaratan Sistem untuk Platform Linux dan macOS Target**

- Perpustakaan runtime GCC 6 (atau yang lebih baru).
- [libgdiplus](https://github.com/mono/libgdiplus), sebuah implementasi sumber terbuka dari API GDI+.
- Ketergantungan dari .NET Core Runtime. Menginstal .NET Core Runtime itu sendiri TIDAK diperlukan.
- Untuk Python 3.5–3.7: build `pymalloc` dari Python diperlukan. Opsi build `--with-pymalloc` diaktifkan secara default. Biasanya, build `pymalloc` dari Python ditandai dengan akhiran `m` pada nama file.
- `libpython` library bersama. Opsi build Python `--enable-shared` dinonaktifkan secara default, dan beberapa distribusi Python tidak menyertakan library bersama `libpython`. Pada beberapa platform Linux, Anda dapat menginstal library bersama `libpython` menggunakan manajer paket (misalnya, `sudo apt-get install libpython3.7`). Masalah umum adalah library `libpython` diinstal di lokasi nonstandar untuk library bersama. Anda dapat menyelesaikannya dengan menggunakan opsi build Python untuk mengatur jalur library alternatif saat mengompilasi Python, atau dengan membuat tautan simbolik ke file library `libpython` di lokasi library bersama standar sistem. Biasanya, nama file library bersama `libpython` adalah `libpythonX.Ym.so.1.0` untuk Python 3.5–3.7 atau `libpythonX.Y.so.1.0` untuk Python 3.8 atau yang lebih baru (misalnya, `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **FAQ**

**Apakah saya perlu menginstal Microsoft PowerPoint untuk konversi dan rendering?**

Tidak, PowerPoint tidak diperlukan; Aspose.Slides adalah mesin mandiri untuk [membuat](/slides/id/python-net/create-presentation/), memodifikasi, [mengonversi](/slides/id/python-net/convert-presentation/), dan [merender](/slides/id/python-net/convert-powerpoint-to-png/) presentasi.

**Apakah versi .NET tertentu (Core/5+/6+) diperlukan pada mesin?**

Menginstal .NET Runtime itu sendiri tidak diperlukan, tetapi dependensinya harus ada di Linux/macOS. Ini berarti sistem harus berisi paket-paket yang biasanya diinstal sebagai dependensi .NET, tanpa menginstal runtime secara penuh.

**Font apa yang diperlukan untuk rendering yang tepat?**

Secara praktik, font yang digunakan dalam presentasi atau [pengganti](/slides/id/python-net/font-substitution/) yang tepat harus tersedia. Untuk memastikan rendering yang konsisten pada Linux/macOS, disarankan untuk menginstal paket font umum.

**Mengapa font khusus dirender sebagai fallback atau teks yang hilang di Linux?**

Jika file font memiliki entri tabel nama yang tidak konsisten atau rusak, tumpukan pencocokan font Linux (FreeType/fontconfig) dapat memilih rekaman yang tidak valid, menyebabkan font tidak dapat diselesaikan. Menggunakan versi font dengan tabel nama yang diperbaiki atau menginstal pengganti yang konsisten menyelesaikan masalah tersebut.