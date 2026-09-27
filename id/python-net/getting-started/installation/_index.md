---
title: Instalasi
type: docs
weight: 70
url: /id/python-net/installation/
keywords:
- unduh Aspose.Slides
- instal Aspose.Slides
- gunakan Aspose.Slides
- Instalasi Aspose.Slides
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "Instal Aspose.Slides untuk Python via .NET dari PyPI dengan pip di Windows, Linux, dan macOS, serta instal pustaka native yang dibutuhkan Linux dan macOS."
---
## **Ringkasan**

Artikel ini menjelaskan cara menginstal Aspose.Slides untuk Python via .NET di Windows, Linux, dan macOS. Paket ini dipublikasikan di [PyPI](https://pypi.org/project/aspose.slides/) dan diinstal dengan pip. Paket ini menyertakan runtime .NET yang digunakannya, sehingga Anda tidak perlu menginstal .NET secara terpisah. Pada Linux dan macOS, runtime tersebut membutuhkan pustaka native yang mungkin tidak disertakan oleh sistem operasi; bagian di bawah ini menyebutkan pustaka tersebut.

Aspose.Slides untuk Python via .NET mendukung Python 3.5 hingga 3.14. PyPI menyediakan paket untuk Windows (32‑bit dan 64‑bit), Linux (x86_64 dan ARM64), serta macOS (Intel dan Apple silicon).

## **Windows**

Di Windows, instal paket menggunakan pip. Tidak diperlukan pustaka lain.

```bash
pip install aspose.slides
```

## **Linux**

Di Linux, runtime .NET yang disertakan dalam paket memerlukan dua pustaka:

- **libgdiplus**, implementasi API grafis Windows GDI+. Tanpa pustaka ini, penyimpanan presentasi akan gagal dengan kesalahan `The type initializer for 'Gdip' threw an exception`.
- **ICU** (International Components for Unicode). Tanpa ICU, proses Python akan berhenti pada pemanggilan pertama Aspose.Slides dengan pesan `Couldn't find a valid ICU package installed on the system`.

Pada Debian dan Ubuntu, instal kedua pustaka tersebut dengan apt:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

Nama paket ICU mencantumkan versinya: `libicu76` adalah paket untuk Debian 13. Pada Debian 12, instal `libicu72`, dan pada Ubuntu 24.04, `libicu74`. Untuk menemukan nama paket pada sistem Anda, jalankan:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

Kemudian instal paket ke dalam lingkungan virtual. Pada rilis Debian dan Ubuntu saat ini, Python sistem tidak mengizinkan `pip install` di luar lingkungan virtual dan akan berhenti dengan kesalahan `externally-managed-environment`.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

Jalankan skrip Anda dengan lingkungan virtual yang sama diaktifkan. Jika Anda menggunakan Python yang tidak dikelola distro Anda, seperti yang ada pada gambar resmi `python` Docker, Anda juga dapat menjalankan `pip install aspose.slides` tanpa lingkungan virtual.

Font yang digunakan dalam presentasi Anda, atau substitusi yang cocok, harus diinstal pada sistem agar teks dapat dirender dengan benar ketika Anda mengonversi slide ke PDF atau gambar.

## **macOS**

Kami belum memverifikasi instalasi pada macOS. Pada macOS, Aspose.Slides memerlukan prasyarat berikut:

- **Python dengan pustaka bersama**, yaitu Python yang dibangun dengan opsi konfigurasi `--enable-shared`. Jika Anda menginstal Python dengan [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos), tetapkan variabel lingkungan `PYTHON_CONFIGURE_OPTS` ke `--enable-shared` saat menginstal versi Python.
- **Pustaka libpython di direktori pustaka sistem**. Python yang diinstal lewat pyenv menyimpan pustaka libpython‑nya, seperti *libpython3.9.dylib*, di bawah *~/.pyenv/versions*; buat tautan simbolik ke sana di */usr/local/lib*.
- **libgdiplus**, implementasi API grafis Windows GDI+. Homebrew menyediakan paket ini sebagai `mono-libgdiplus`.

Kemudian instal paket dengan pip.

## **Periksa Instalasi**

Untuk memeriksa instalasi, simpan contoh pertama di [Create Presentations](/slides/id/python-net/create-presentation/) sebagai *hello.py* dan jalankan `python hello.py`. Skrip tersebut akan menyimpan *new_presentation.pptx* di folder saat ini.

## **Pembaruan**

Untuk memperbarui instalasi yang ada ke versi terbaru, jalankan perintah berikut di lingkungan tempat Anda menginstal paket:

```bash
pip install --upgrade aspose.slides
```

## **FAQ**

**Apakah saya dapat menginstal Aspose.Slides di lingkungan virtual?**

Ya. Anda dapat menginstalnya di lingkungan virtual Python mana pun menggunakan pip. Pustaka native yang dibutuhkan Linux dan macOS diinstal pada sistem, bukan di dalam lingkungan virtual.

**Apakah saya dapat menggunakan Aspose.Slides di dalam kontainer Docker?**

Ya. Gambar Docker harus menyertakan pustaka native yang sama seperti pada sistem Linux — libgdiplus dan ICU — serta font yang digunakan oleh presentasi Anda.

**Apakah ada versi gratis atau batasan percobaan?**

Ya. Tanpa lisensi, Aspose.Slides berjalan dalam mode evaluasi: ia menambahkan watermark evaluasi pada setiap slide yang disimpan dan memotong teks yang dibaca dari presentasi. Untuk menghapus batasan ini, terapkan [lisensi](/slides/id/python-net/licensing/) yang valid.