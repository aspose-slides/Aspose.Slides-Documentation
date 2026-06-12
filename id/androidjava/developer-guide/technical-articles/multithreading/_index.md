---
title: Multithreading di Aspose.Slides untuk Android via Java
linktitle: Multithreading
type: docs
weight: 310
url: /id/androidjava/multithreading/
keywords:
- multithreading
- banyak thread
- pekerjaan paralel
- mengonversi slide
- slide ke gambar
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Multithreading Aspose.Slides untuk Android via Java meningkatkan pemrosesan PowerPoint dan OpenDocument. Temukan praktik terbaik untuk alur kerja presentasi yang efisien."
---
## **Pendahuluan**

Meskipun kerja paralel dengan presentasi memungkinkan (selain parsing/memuat/menyalin) dan segala sesuatunya berjalan baik (kebanyakan waktu), ada kemungkinan kecil Anda mendapatkan hasil yang tidak tepat saat menggunakan perpustakaan ini dalam banyak thread.

Kami sangat menyarankan agar Anda **tidak** menggunakan satu instance [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) dalam lingkungan multithreading karena dapat menghasilkan kesalahan atau kegagalan yang tidak dapat diprediksi dan tidak mudah terdeteksi.

Tidak **aman** untuk memuat, menyimpan, dan/atau menyalin sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) dalam banyak thread. Operasi semacam itu **tidak** didukung. Jika Anda perlu melakukan tugas tersebut, Anda harus memparalelkan operasi menggunakan beberapa proses satu‑thread—dan masing‑masing proses tersebut harus menggunakan instance presentasi masing‑masing.

## **Mengonversi Slide Presentasi ke Gambar secara Paralel**

Misalkan kita ingin mengonversi semua slide dari presentasi PowerPoint ke gambar PNG secara paralel. Karena tidak aman menggunakan satu instance `Presentation` dalam banyak thread, kita membagi slide presentasi menjadi presentasi terpisah dan mengonversi slide menjadi gambar secara paralel, dengan menggunakan setiap presentasi dalam thread terpisah. Contoh kode berikut menunjukkan cara melakukannya.

```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// Ekstrak slide i ke presentasi terpisah.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// Konversi slide menjadi gambar dalam tugas terpisah.
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
			IImage image = null;
			try {
				ISlide slide = slidePresentation.getSlides().get_Item(0);

				image = slide.getImage(imageScale, imageScale);
				String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
				image.save(imageFilePath, ImageFormat.Png);
			} finally {
				if (image != null) image.dispose();
				slidePresentation.dispose();
			}
		}
	}));
}

// Tunggu semua tugas selesai.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```

## **FAQ**

**Apakah saya perlu memanggil pengaturan lisensi di setiap thread?**

Tidak. Cukup lakukan sekali per proses/domain aplikasi sebelum thread dimulai. Jika [license setup](/slides/id/androidjava/licensing/) mungkin dipanggil secara bersamaan (misalnya, selama inisialisasi malas), sinkronkan pemanggilan itu karena metode pengaturan lisensi itu sendiri tidak thread‑safe.

**Apakah saya dapat memindahkan objek `Presentation` atau `Slide` antar thread?**

Menyampaikan objek presentasi "live" antar thread tidak disarankan: gunakan instance independen per thread atau buat sebelumnya presentasi/kontainer slide terpisah untuk setiap thread. Pendekatan ini mengikuti rekomendasi umum untuk tidak berbagi satu instance presentasi di seluruh thread.

**Apakah aman memparalelkan ekspor ke format yang berbeda (PDF, HTML, gambar) asalkan setiap thread memiliki instance `Presentation`‑nya sendiri?**

Ya. Dengan instance independen dan jalur output terpisah, tugas semacam itu biasanya dapat diparalelkan dengan benar; hindari penggunaan objek presentasi bersama dan aliran I/O yang dibagikan.

**Apa yang harus saya lakukan dengan pengaturan font global (folder, substitusi) dalam multithreading?**

Inisialisasi semua [font settings](/slides/id/androidjava/powerpoint-fonts/) global sebelum memulai thread dan jangan ubah selama kerja paralel. Hal ini menghilangkan kondisi balapan saat mengakses sumber daya font yang dibagikan.