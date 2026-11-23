---
title: Automatisasi Personalisasi Presentasi dengan Mail Merge
linktitle: Mail Merge
type: docs
weight: 233
url: /id/net/mail-merge/
keywords:
- Mail Merge
- personalisasi presentasi
- templat presentasi
- placeholder teks
- sumber data
- CSV
- Excel
- XLSX
- JSON
- XML
- gabungkan data
- hasilkan presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara menggunakan Mail Merge di Aspose.Slides untuk .NET untuk mengisi templat presentasi dengan data dan menghasilkan presentasi PowerPoint yang dipersonalisasi dari sumber CSV, Excel, JSON, dan XML."
---
## **Mail Merge dalam Presentasi PowerPoint**

Aspose.Slides untuk .NET memungkinkan Anda membuat presentasi PowerPoint secara otomatis menggunakan templat dan sumber data. Mail Merge mengisi placeholder templat dengan data dan membuat satu presentasi yang berisi slide templat berulang untuk setiap set data atau presentasi terpisah untuk setiap set data.

Fungsionalitas ini berguna untuk menghasilkan katalog produk, presentasi pribadi, laporan, sertifikat, proposal, daftar harga, dan dokumen lain di mana struktur presentasi tetap sama sementara kontennya bervariasi.

![Mail Merge: before and after](mail-merge-before-after.png)


## **Cara Kerja Mail Merge**

Mail Merge menggunakan presentasi PowerPoint sebagai templat dan mengganti placeholder dengan nilai dari sumber data.

![Mail Merge workflow](mail-merge-workflow.png)

Sebuah placeholder adalah nama bidang yang dikelilingi oleh kurung kurawal ganda, seperti `{{title}}` atau `{{price}}`. Placeholder dapat ditempatkan dalam teks pada bentuk, sel tabel, bentuk yang dikelompokkan, dan catatan pembicara.

Sebagai contoh, slide templat dapat berisi teks berikut:

- `Product: {{title}}`
- `Price: {{price}}`
- `Description: {{description}}`

Ketika sumber data berisi nilai berikut:

| Field | Value |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14-inch display, 16 GB RAM |

Mail Merge mengganti placeholder dengan nilai yang sesuai, menghasilkan slide dengan informasi produk yang sebenarnya.

Nama bidang tidak sensitif huruf besar/kecil, sehingga `{{title}}` dan `{{Title}}` merujuk ke bidang yang sama.

Aturan berikut berlaku saat mengganti placeholder:

- Placeholder diganti pada slide, termasuk bentuk yang dikelompokkan dan sel tabel, serta dalam catatan pembicara.
- Placeholder pada slide master dan slide tata letak tidak diganti.
- Placeholder yang bidangnya tidak ada dalam set data tetap tidak berubah.
- Nilai bidang kosong mengganti placeholder dengan string kosong.
- Teks yang dimasukkan mewarisi format karakter pertama dari placeholder.
- Nilai tidak boleh mengandung teks placeholder, karena teks yang dimasukkan dapat diproses lagi dan diganti oleh bidang lain.

Presentasi templat asli tidak diubah selama operasi penggabungan dan harus berisi setidaknya satu slide.

## **Sumber Data yang Didukung**

Mail Merge mendukung dua cara menyediakan data:

- Membuat sumber data secara programatis menggunakan `IMailMergeDataSource`.
- Membaca data dari file atau aliran CSV, XLSX, JSON, atau XML.

Format data dideteksi dari isinya, bukan dari ekstensi file. Aliran yang tidak mendukung pencarian posisi juga didukung.

Sumber data harus berisi setidaknya satu set data. Setiap set data mewakili satu salinan templat yang akan diisi dengan nilai-nilainya.

Jika konten data tidak dapat dikenali sebagai format yang didukung, `NotSupportedException` dilemparkan. Jika konten dikenali tetapi tidak memenuhi persyaratan format, `InvalidDataException` dilemparkan. Pesan pengecualian berisi lokasi kesalahan dalam data.

### **JSON**

Sumber data JSON harus memiliki objek akar yang berisi array `sets`. Setiap elemen array mewakili satu set data dan harus berisi array `fields`. Setiap bidang harus memiliki string `name` dan `value`.

Properti opsional `version` harus `"1.0"`, dan properti opsional `type` pada bidang harus `"text"`. Nama properti bersifat sensitif huruf besar/kecil. Properti yang tidak dikenal diabaikan.

Data JSON dibaca sebagai UTF-8, atau sebagai UTF-16 ketika data dimulai dengan byte order mark (BOM).

Contoh berikut berisi dua set data:

```json
{
  "version": "1.0",
  "sets": [
    {
      "fields": [
        { "name": "title", "value": "Laptop X1" },
        { "name": "price", "value": "$999" }
      ]
    },
    {
      "fields": [
        { "name": "title", "value": "Tablet S2" },
        { "name": "price", "value": "$499" }
      ]
    }
  ]
}
```

### **XML**

Sumber data XML harus memiliki elemen akar `template` yang berisi elemen `sets`. Setiap elemen `set` berisi elemen `field`, dan setiap bidang harus berisi elemen `name` dan `value`.

Elemen `value` yang kosong diperlakukan sebagai string kosong. Nama elemen sensitif huruf besar/kecil. Elemen dan komentar yang tidak dikenal diabaikan. Pengkodean ditentukan oleh deklarasi XML. Definisi tipe dokumen (DTD) tidak diperbolehkan.

```xml
<?xml version="1.0" encoding="utf-8"?>
<template>
  <sets>
    <set>
      <field>
        <name>title</name>
        <value>Laptop X1</value>
      </field>
      <field>
        <name>price</name>
        <value>$999</value>
      </field>
    </set>
    <set>
      <field>
        <name>title</name>
        <value>Tablet S2</value>
      </field>
      <field>
        <name>price</name>
        <value>$499</value>
      </field>
    </set>
  </sets>
</template>
```

### **CSV**

Data CSV menggunakan titik koma sebagai pemisah nilai.

Baris pertama berisi nama bidang dan berakhir pada nama bidang kosong pertama. Setiap baris berikutnya mewakili satu set data. Data berakhir pada baris kosong pertama.

Aturan berikut berlaku:

- Nilai yang hilang di akhir baris diperlakukan sebagai string kosong.
- Nilai di luar nama bidang yang didefinisikan diabaikan.
- Nilai yang mengandung titik koma, tanda kutip, atau jeda baris harus dikelilingi tanda kutip.
- Tanda kutip di dalam nilai yang dikutip harus digandakan.
- Data dibaca sebagai UTF-8, atau sebagai UTF-16 ketika dimulai dengan byte order mark (BOM).

Contoh:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### **XLSX**

Data XLSX dibaca dari lembar kerja pertama.

Lembar kerja mengikuti aturan yang sama dengan CSV:

- Baris pertama berisi nama bidang dan berakhir pada sel kosong pertama.
- Setiap baris berikutnya mewakili satu set data.
- Data berakhir pada baris kosong pertama.
- Sel kosong diperlakukan sebagai string kosong.
- Nilai numerik dikonversi menjadi teks menggunakan kultur invarian.

## **Membuat Satu Presentasi**

Metode `MergeToSinglePresentation` membuat satu presentasi yang berisi salinan slide templat untuk setiap set data. Setiap salinan diisi dengan data yang sesuai.

Urutan set data menentukan urutan grup slide dalam presentasi yang dihasilkan.

### **Merging Data from a File**

Contoh berikut memuat templat dan file data JSON, membuat satu presentasi yang berisi slide untuk semua set data, dan menyimpan hasilnya.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, "products.json"))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

Data juga dapat dibaca dari aliran. Aliran dibaca mulai dari posisi saat ini dan tidak ditutup oleh operasi Mail Merge.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xml"))
using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, data))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

### **Creating a Data Source in Code**

Anda dapat membangun sumber data secara programatis menggunakan `MailMergeDataSource` dan `MailMergeDataSet`. Tambahkan set data untuk setiap rekaman dan definisikan bidangnya menggunakan metode `AddText`.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet laptop = source.AddDataSet();
laptop.AddText("title", "Laptop X1");
laptop.AddText("price", "$999");

IMailMergeDataSet tablet = source.AddDataSet();
tablet.AddText("title", "Tablet S2");
tablet.AddText("price", "$499");

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, source))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

Dalam contoh ini, slide templat diulang dua kali: sekali untuk laptop dan sekali untuk tablet. Placeholder diisi menggunakan nilai yang didefinisikan pada masing‑ma masing set data.

## **Membuat Banyak Presentasi**

Jika Anda membutuhkan presentasi terpisah untuk setiap set data, gunakan metode `MergeToMultiplePresentations`.

Metode ini memproses set data satu per satu, membuat presentasi dari templat, mengisinya dengan data saat ini, dan meneruskan presentasi yang dihasilkan ke sebuah handler.

Handler dipanggil sekali untuk setiap set data, dalam urutan data asli.

### **Saving Each Presentation**

Contoh berikut membaca data dari file CSV dan menyimpan setiap presentasi yang dihasilkan sebagai file terpisah.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.csv",
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

Properti `args.Index` memberikan indeks berbasis nol dari set data saat ini. Dalam contoh, properti ini digunakan untuk menghasilkan nama file berurutan mulai dari `product_1.pptx`.

Data juga dapat dibaca dari aliran:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xlsx"))
using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        data,
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

### **Using Data Set Values to Name Files**

Handler menerima baik presentasi yang dihasilkan maupun informasi tentang set data yang digunakan untuk membuatnya. Anda dapat menggunakan nilai set data untuk membangun nama file yang bermakna.

Misalnya, kode berikut menyimpan setiap presentasi menggunakan judul produk:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string title = args.DataSet.GetText("title");
            string fileName = title != null
                ? title
                : "product_" + (args.Index + 1);

            presentation.Save(fileName + ".pptx", SaveFormat.Pptx);
        });
}
```

Properti `DataSet` mengembalikan set data yang digunakan untuk mengisi presentasi saat ini. Metode `GetText` mengambil nilai bidang yang ditentukan, atau `null` jika bidang tidak ada.

Ini memungkinkan Anda menggunakan nilai data untuk menamai file, mengatur output, atau melakukan pemrosesan tambahan dalam handler.

## **Handling Generated Presentations**

`MergeToMultiplePresentations` menggunakan delegasi `MailMergedPresentationHandler` untuk memproses setiap presentasi yang dihasilkan.

Handler menerima dua argumen:

- `presentation` — presentasi yang dibuat dari templat dan diisi dengan set data saat ini.
- `args` — informasi tentang presentasi yang dihasilkan, termasuk indeks set data dan set data itu sendiri.

Presentasi yang dihasilkan dimiliki oleh operasi Mail Merge dan dibuang segera setelah handler mengembalikan nilai. Karena itu, Anda harus menyimpannya atau menyalin data yang diperlukan di dalam handler. Jangan menyimpan referensi ke presentasi setelah handler selesai atau membuangnya secara manual.

Handler dijalankan pada thread pemanggil, satu presentasi pada satu waktu, sesuai urutan set data. Hanya satu presentasi yang dihasilkan disimpan dalam memori pada satu waktu, sehingga pendekatan ini cocok untuk memproses sumber data besar tanpa menahan semua presentasi dalam memori secara bersamaan.

Jika handler melempar pengecualian, operasi Mail Merge berhenti dan pengecualian diteruskan ke pemanggil tanpa perubahan. Presentasi yang sudah diproses tidak terpengaruh, dan set data yang tersisa tidak diproses.

Contoh berikut menyimpan presentasi yang dihasilkan ke direktori khusus:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

string outputFolder = "output";
Directory.CreateDirectory(outputFolder);

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string path = Path.Combine(
                outputFolder,
                "product_" + (args.Index + 1) + ".pptx");

            presentation.Save(path, SaveFormat.Pptx);
        });
}
```

## **Working with Mail Merge Data**

Kelas `MailMergeDataSource` mewakili koleksi terurut dari set data. Ini dapat digunakan untuk membuat data dalam kode, memeriksa jumlah set data, dan mengakses set data individual berdasarkan indeks.

### **Getting the Number of Data Sets**

Properti `Count` mengembalikan jumlah set data dalam sumber.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### **Accessing a Data Set by Index**

Properti `Item(int)` menyediakan akses ke set data pada indeks berbasis nol yang ditentukan.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Contoh ini mengambil judul set data kedua.

### **Adding Text Fields**

Metode `AddText` menambahkan bidang teks bernama ke set data. Nilai bidang menggantikan semua placeholder yang cocok dalam templat.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Nilai kosong menghapus placeholder yang bersangkutan dari teks yang dihasilkan. Jika bidang tidak ditambahkan ke set data, placeholder tetap tidak berubah.

### **Reading Text Fields**

Metode `GetText` mengambil nilai sebuah bidang berdasarkan nama. Nama bidang tidak sensitif huruf besar/kecil.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Jika bidang tidak ada atau nama bidang yang diberikan `null`, `GetText` mengembalikan `null`.

## **Summary**

Mail Merge di Aspose.Slides untuk .NET menyediakan cara yang nyaman untuk menghasilkan presentasi berbasis data dari templat yang dapat digunakan kembali.

Anda dapat menggunakannya untuk:

- Mengisi templat presentasi dengan nilai dari sumber data.
- Menghasilkan satu presentasi yang berisi slide templat berulang untuk beberapa set data.
- Membuat presentasi terpisah untuk setiap set data.
- Membaca data dari file atau aliran CSV, XLSX, JSON, dan XML.
- Membuat sumber data langsung dalam kode.
- Memproses dan menyimpan presentasi yang dihasilkan secara berurutan menggunakan handler.

Dengan menggabungkan templat yang dapat digunakan kembali dengan data terstruktur, Anda dapat mengotomatisasi pembuatan banyak presentasi sambil memisahkan desain templat dan logika pemrosesan data.

## **Frequently Asked Questions**

**Apakah saya dapat menggunakan placeholder yang sama berkali‑kali dalam sebuah templat?**

Ya. Setiap kemunculan placeholder dengan nama bidang yang cocok diganti dengan nilai yang sesuai dari set data saat ini.

**Apakah nama bidang sensitif huruf besar/kecil?**

Tidak. Nama placeholder dan bidang data tidak sensitif huruf besar/kecil. Misalnya, `{{title}}`, `{{Title}}`, dan `{{TITLE}}` merujuk ke bidang yang sama.

**Apa yang terjadi jika sebuah bidang tidak ada dalam set data?**

Jika set data tidak berisi bidang yang dirujuk oleh placeholder, placeholder tersebut tetap tidak berubah dalam presentasi yang dihasilkan.

**Apa yang terjadi jika sebuah bidang memiliki nilai kosong?**

Nilai bidang kosong menggantikan placeholder dengan string kosong. Teks placeholder dihapus, sehingga tidak ada teks di tempatnya.

**Apakah saya dapat mempertahankan format placeholder saat menggantinya?**

Teks pengganti mewarisi format karakter pertama dari placeholder. Terapkan format yang diinginkan pada teks placeholder dalam templat sebelum melakukan penggabungan.

**Apakah Mail Merge mengganti placeholder pada slide master atau slide tata letak?**

Tidak. Mail Merge mengganti placeholder dalam konten yang didukung pada slide presentasi, termasuk bentuk, bentuk yang dikelompokkan, sel tabel, dan catatan pembicara. Placeholder pada slide master dan tata letak tidak diganti.

**Apakah templat presentasi diubah selama penggabungan?**

Tidak. Templat asli tidak diubah oleh operasi penggabungan. Anda dapat menggunakannya kembali untuk menghasilkan presentasi dari sumber data yang sama atau berbeda.

**Apakah saya dapat menghasilkan presentasi terpisah untuk setiap set data?**

Ya. Gunakan `MergeToMultiplePresentations` dan simpan setiap presentasi yang dihasilkan di dalam handler. Handler dipanggil secara berurutan untuk setiap set data.

**Apakah saya dapat menggabungkan semua set data menjadi satu presentasi?**

Ya. Gunakan `MergeToSinglePresentation`. Metode ini membuat satu presentasi output yang berisi salinan slide templat untuk setiap set data, sesuai urutan sumber data.

**Apakah saya dapat menggunakan sumber data tanpa menyimpannya ke file?**

Ya. Anda dapat membuat `MailMergeDataSource` dalam kode, menambahkan set data, dan mengisi bidang menggunakan `AddText`. Ini berguna ketika data sudah tersedia dalam aplikasi Anda.

**Apakah Mail Merge mendeteksi format data dari ekstensi file?**

Tidak. Format data dideteksi dari isi file, sehingga sumber data yang didukung tidak harus menggunakan ekstensi file tertentu.

**Apakah saya dapat membaca data dari aliran yang tidak mendukung pencarian posisi?**

Ya. Mail Merge mendukung aliran yang tidak dapat dicari posisinya.

**Apa yang terjadi jika sumber data kosong atau tidak berisi set data?**

Sumber data harus berisi setidaknya satu set data. Pastikan setidaknya ada satu rekaman sebelum memulai operasi penggabungan.

**Apa yang terjadi jika sumber data memiliki format tidak valid?**

Jika konten tidak dikenali sebagai salah satu format data yang didukung, `NotSupportedException` dilemparkan. Jika dikenali tetapi tidak sesuai format, `InvalidDataException` dilemparkan. Pesan pengecualian mencakup informasi tentang lokasi kesalahan.

**Apakah saya dapat menggunakan presentasi yang dihasilkan setelah handler selesai?**

Presentasi yang diteruskan ke handler `MergeToMultiplePresentations` dimiliki oleh Mail Merge dan dibuang setelah handler selesai. Simpan atau salin konten yang Anda butuhkan di dalam handler, dan jangan menyimpan atau membuang presentasi tersebut secara manual.

**Apakah handler dipanggil secara paralel?**

Tidak. Presentasi yang dihasilkan diproses secara berurutan, pada thread pemanggil. Hanya satu presentasi yang dihasilkan disimpan dalam memori pada satu waktu oleh operasi ini.

**Apa yang terjadi jika terjadi pengecualian di dalam handler?**

Operasi penggabungan berhenti, dan pengecualian diteruskan ke pemanggil tanpa perubahan. Presentasi yang sudah diproses tidak terpengaruh, dan set data yang tersisa tidak diproses.

**Apakah saya dapat menggunakan nilai bidang untuk menghasilkan nama file output?**

Ya. Handler menyediakan set data saat ini melalui argumennya. Gunakan `GetText` untuk mengambil nilai bidang dan membangun nama file untuk setiap presentasi yang dihasilkan. Pastikan nilai tersebut valid untuk nama file di lingkungan target Anda.